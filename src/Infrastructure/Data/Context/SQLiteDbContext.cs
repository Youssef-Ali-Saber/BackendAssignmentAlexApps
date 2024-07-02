using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context;

public class SQLiteDbContext : IdentityDbContext<ApplicationUser>
{
    public SQLiteDbContext(DbContextOptions<SQLiteDbContext> options) : base(options)
    {
    }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Store>()
            .HasOne(s => s.Merchant)
            .WithMany(m => m.Stores)
            .HasForeignKey(s => s.MerchantId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Store)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.StoreId);

        modelBuilder.Entity<Cart>()
            .HasOne(c => c.User)
            .WithOne(u => u.Cart)
            .HasForeignKey<Cart>(c => c.UserId);

        modelBuilder.Entity<CartItem>()
            .HasOne(ci => ci.Cart)
            .WithMany(c => c.CartItems)
            .HasForeignKey(ci => ci.CartId);

        modelBuilder.Entity<CartItem>()
            .HasOne(ci => ci.Product)
            .WithMany()
            .HasForeignKey(ci => ci.ProductId);

        modelBuilder.Entity<IdentityRole>().HasData(
           new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Merchant", NormalizedName = "MERCHANT" ,ConcurrencyStamp = Guid.NewGuid().ToString() },
           new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER" ,ConcurrencyStamp = Guid.NewGuid().ToString() }
       );
    }
}
