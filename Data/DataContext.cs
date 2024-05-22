using MBBE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MBBE.Data
{
    public class DataContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>, UserRoleMap, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Promotions> Promotions { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.CategoryId, pc.ProductID });
            modelBuilder.Entity<ProductCategory>()
                .HasOne(p => p.Product)
                .WithMany(pc => pc.ProductCategories)
                .HasForeignKey(c => c.ProductID);
            modelBuilder.Entity<ProductCategory>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.ProductCategories)
                .HasForeignKey(c => c.CategoryId);
            modelBuilder.Entity<Promotions>()
                .HasKey(p => p.PromotionId);
            modelBuilder.Entity<UserRoleMap>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<UserRoleMap>()
                .HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoleMaps)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            modelBuilder.Entity<UserRoleMap>()
                .HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoleMaps)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            modelBuilder.Entity<User>()
                .HasIndex(x => x.Phone).IsUnique();
        }
    }
}
