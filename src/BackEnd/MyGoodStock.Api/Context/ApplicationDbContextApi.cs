using Microsoft.EntityFrameworkCore;
using MyGoodStock.Api.Models.Entity;

namespace MyGoodStock.Api.Context
{
    public class ApplicationDbContextApi : DbContext
    {
        public ApplicationDbContextApi(DbContextOptions<ApplicationDbContextApi> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da tabela Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Description).HasMaxLength(500);
                entity.Property(p => p.CostPrice).HasColumnType("decimal(18,2)");
                entity.Property(p => p.SalePrice).HasColumnType("decimal(18,2)");
            });

            // Configuração da tabela StockMovement
            modelBuilder.Entity<StockMovement>(entity =>
            {
                entity.HasKey(sm => sm.Id);
                entity.Property(sm => sm.MovementType).IsRequired().HasMaxLength(10); // "Entrada" ou "Saída"
                entity.HasOne(sm => sm.Product)
                      .WithMany()
                      .HasForeignKey(sm => sm.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuração da tabela Sale
            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.TotalValue).HasColumnType("decimal(18,2)");
            });

            // Configuração da tabela SaleItem
            modelBuilder.Entity<SaleItem>(entity =>
            {
                entity.HasKey(si => si.Id);
                entity.HasOne(si => si.Sale)
                      .WithMany(s => s.SaleItems)
                      .HasForeignKey(si => si.SaleId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(si => si.Product)
                      .WithMany()
                      .HasForeignKey(si => si.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.Property(si => si.Price).HasColumnType("decimal(18,2)");
            });


            // Configuração da tabela MonthlyProfitReport
            modelBuilder.Entity<MonthlyProfitReport>(entity =>
            {
                entity.HasKey(mpr => mpr.Id);
                entity.Property(mpr => mpr.Month).IsRequired();
                entity.Property(mpr => mpr.TotalProfit).HasColumnType("decimal(18,2)");
            });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<MonthlyProfitReport> MonthlyProfitReports { get; set; }
    }
}
