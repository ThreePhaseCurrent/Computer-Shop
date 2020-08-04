using System;
using System.Reflection.PortableExecutable;
using ComputerShop.API.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ComputerShop.API.Entities
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<CharacterValue> CharacterValues { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<DeliveryCompany> DeliveryCompanies { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderList> OrderLists { get; set; }
        public virtual DbSet<OrderType> OrderTypes { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<UserBasket> UserBaskets { get; set; }
        public virtual DbSet<UserDevice> UserDevices { get; set; }
        public virtual DbSet<Сharacteristic> Сharacteristics { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentId).UseIdentityAlwaysColumn();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Message).IsRequired();

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_comment_users");
            });
            
            builder.Entity<UserBasket>(entity =>
            {
                entity.HasKey(e => e.BasketId)
                    .HasName("userbasket_pkey");

                entity.Property(e => e.BasketId).UseIdentityAlwaysColumn();

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserBasket)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_basket_users");
            });
            
            builder.Entity<Сharacteristic>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
            
            builder.Entity<CharacterValue>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.CharacterValue)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK_characterValue_category");

                entity.HasOne(d => d.IdCharacterNavigation)
                    .WithMany(p => p.CharacterValue)
                    .HasForeignKey(d => d.IdCharacter)
                    .HasConstraintName("FK_characterValue_characteristic");
            });
            
            builder.Entity<Discount>(entity =>
            {
                entity.Property(e => e.DiscountId).UseIdentityAlwaysColumn();

                entity.Property(e => e.Value).HasColumnType("numeric");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Discount)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_diskont_product");
            });
            
            builder.Entity<Manufacturer>(entity =>
            {
                entity.HasKey(e => e.ManufactureId)
                    .HasName("manufacturer_pkey");

                entity.Property(e => e.ManufactureId).UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
            
            builder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.PriductId)
                    .HasName("product_pkey");

                entity.Property(e => e.PriductId).UseIdentityAlwaysColumn();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("numeric");

                entity.Property(e => e.ProductImage).IsRequired();

                entity.Property(e => e.ShortDescription).IsRequired();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_product_category");

                entity.HasOne(d => d.DiscountNavigation)
                    .WithMany(p => p.ProductNavigation)
                    .HasForeignKey(d => d.DiscountId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_product_diskont");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_product_manufacturer");
            });
            
            builder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("product_category_pkey");

                entity.Property(e => e.CategoryId).UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
            
            builder.Entity<UserDevice>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.CustomName).HasMaxLength(70);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.UserDevice)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_userdevice_category");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.UserDevice)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_userdevice_product");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDevice)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_userdevice_users");
            });
            
            builder.Entity<DeliveryCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("DeliveryCompany_pkey");

                entity.Property(e => e.CompanyId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("bit varying(100)");
            });
            
            builder.Entity<Delivery>(entity =>
            {
                entity.Property(e => e.DeliveryId).ValueGeneratedNever();

                entity.Property(e => e.Delivered)
                    .IsRequired()
                    .HasColumnType("bit(1)");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Delivery)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_delivery_deliverycompany");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Delivery)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_delivery_order");
            });
            
            builder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).UseIdentityAlwaysColumn();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_order_type");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_order_users");
            });

            builder.Entity<OrderList>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Discount)
                    .WithMany()
                    .HasForeignKey(d => d.DiskontId)
                    .HasConstraintName("FK_orderlist_diskont");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orderlist_order");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orderlist_product");
            });

            builder.Entity<OrderType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("OrderType_pkey");

                entity.Property(e => e.TypeId).ValueGeneratedNever();
            });
        }
    }
}
