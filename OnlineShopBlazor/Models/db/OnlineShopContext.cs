using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopBlazor.Models.Db;

public partial class OnlineShopContext : DbContext
{
    public OnlineShopContext()
    {
    }

    public OnlineShopContext(DbContextOptions<OnlineShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<BestSellingFinal> BestSellingFinals { get; set; }

    public virtual DbSet<BestSellingProduct> BestSellingProducts { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductGalery> ProductGaleries { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<Testview> Testviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-BKMN0VK\\MSSQLSERVER2022;Database=OnlineShop;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BestSellingFinal>(entity =>
        {
            entity.ToView("BestSellingFinal");
        });

        modelBuilder.Entity<BestSellingProduct>(entity =>
        {
            entity.ToView("BestSellingProducts");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Testview>(entity =>
        {
            entity.ToView("testview");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
