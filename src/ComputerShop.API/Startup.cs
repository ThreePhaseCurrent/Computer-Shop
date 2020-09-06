using System;
using System.IO;
using AutoMapper;
using ComputerShop.API.Extensions;
using ComputerShop.API.Mapping;
using ComputerShop.API.Models;
using ComputerShop.Core.Entities;
using ComputerShop.Infrastructure.Data;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.PlatformAbstractions;

namespace ComputerShop.API
{
    //dotnet ef database update -c IdentityDb
    
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<ApplicationDbContext>(options => 
            //     options.UseSqlServer(Configuration["ComputerShopDb:ConnectionString"]));

            //add postgresql db
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration["ComputerShopDb:PostgreSql:ConnectionString"]));
            
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            //register services
            services.AddServices();
            
            services.AddAutoMapper(typeof(Startup));

            var mapperConfig = new MapperConfiguration(expression =>
            {
                expression.AddProfile(new AutoMapping());
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            var authOptionsConfig = Configuration.GetSection("Auth");
            services.Configure<AuthOptions>(authOptionsConfig);

            var authOptions = authOptionsConfig.Get<AuthOptions>();

            services.AddControllers().AddFluentValidation();
            services.AddHealthChecks();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authOptions.Issuer,
                        
                        ValidateAudience = true,
                        ValidAudience = authOptions.Audience,
                        
                        ValidateLifetime = true,
                        
                        IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                });
            services.AddAuthorization();
            
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo(){Title = "Computer Shop Api", Version = "v1"});
                
                //Determine base path for the application.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;

                //Set the comments path for the swagger json and ui.
                var xmlPath = Path.Combine(basePath, "ComputerShop.API.xml"); 
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors();
 
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Computer Shop Api");
            });
            
            //create db
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.EnsureCreated();
            }
            
            //test data
            InitData.SeedData(serviceProvider);
        }
    }
}