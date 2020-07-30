using System;
using System.Linq;
using System.Threading.Tasks;
using ComputerShop.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerShop.API.Data
{
    public class InitData
    {
        public static void SeedData(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            string[] roles = { AuthorizationConstants.Roles.ADMIN, AuthorizationConstants.Roles.CLIENT };

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);
            
                if (!context.Roles.Any(r => r.Name == role))
                {
                    roleStore.CreateAsync(new IdentityRole(role));
                }
            }

            var user = new ApplicationUser
            {
                ProfileImage = "",
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            
            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user,"Pass@word123");
                user.PasswordHash = hashed;

                var userStore = new UserStore<ApplicationUser>(context);
                var result = userStore.CreateAsync(user);

            }

            AssignRoles(serviceProvider, user.Email, roles.First());

            context.SaveChangesAsync();
        }

        private static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string role)
        {
            UserManager<ApplicationUser> userManager = services.GetService<UserManager<ApplicationUser>>();
            ApplicationUser user = await userManager.FindByEmailAsync(email);
            var result = await userManager.AddToRoleAsync(user, role);

            return result;
        }
    }
}