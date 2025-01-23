using Microsoft.EntityFrameworkCore;
using web_final_projesi.Models;

namespace web_final_projesi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.UnitPrice)
                .HasPrecision(10, 2);

            
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    Username = "admin",
                    Password = "admin123", 
                    Email = "admin@elitmobilya.com",
                    IsActive = true
                }
            );

           
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Oturma Odası",
                    Description = "Oturma Odası Mobilyaları",
                    ImageUrl = "https://images.unsplash.com/photo-1493663284031-b7e3aefcae8e",
                    IsActive = true
                },
                new Category
                {
                    Id = 2,
                    Name = "Yatak Odası",
                    Description = "Yatak Odası Mobilyaları",
                    ImageUrl = "https://images.unsplash.com/photo-1505693416388-ac5ce068fe85",
                    IsActive = true
                },
                new Category
                {
                    Id = 3,
                    Name = "Mutfak",
                    Description = "Mutfak Mobilyaları",
                    ImageUrl = "https://images.unsplash.com/photo-1556912167-f556f1f39fdf",
                    IsActive = true
                },
                new Category
                {
                    Id = 4,
                    Name = "Çalışma Odası",
                    Description = "Çalışma Odası Mobilyaları",
                    ImageUrl = "https://images.unsplash.com/photo-1486946255434-2466348c2166",
                    IsActive = true
                },
                new Category
                {
                    Id = 5,
                    Name = "Çocuk Odası",
                    Description = "Çocuk Odası Mobilyaları",
                    ImageUrl = "https://images.unsplash.com/photo-1558021212-51b6ecfa0db9",
                    IsActive = true
                },
                new Category
                {
                    Id = 6,
                    Name = "Bahçe",
                    Description = "Bahçe Mobilyaları",
                    ImageUrl = "https://images.unsplash.com/photo-1600210492486-724fe5c67fb3",
                    IsActive = true
                }
            );
        }
    }
} 