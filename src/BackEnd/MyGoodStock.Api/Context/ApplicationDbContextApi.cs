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
                entity.Property(p => p.Name)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(p => p.Description)
                      .HasMaxLength(500);
                entity.Property(p => p.CostPrice)
                      .HasColumnType("decimal(18,2)");
                entity.Property(p => p.SalePrice)
                      .HasColumnType("decimal(18,2)");
                entity.Property(s => s.CreationDate)
                            .HasColumnType("date") // Define o tipo no PostgreSQL como 'date'
                            .IsRequired();
            });

            // Configuração da tabela Client
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name)
                      .IsRequired()
                      .HasMaxLength(250);
                entity.Property(c => c.Address)
                      .IsRequired()
                      .HasMaxLength(250);
                entity.Property(c => c.Cep)
                      .IsRequired()
                      .HasMaxLength(20);
                entity.Property(c => c.Number)
                      .IsRequired()
                      .HasMaxLength(20);
                entity.Property(s => s.CreationDate)
                            .HasColumnType("date") // Define o tipo no PostgreSQL como 'date'
                            .IsRequired();
                // Relação com Sales
                entity.HasMany(c => c.Sales)
                      .WithOne(s => s.Client)
                      .HasForeignKey(s => s.ClientId)
                      .OnDelete(DeleteBehavior.Cascade); // Excluir cliente exclui vendas associadas
            });

            // Configuração da tabela Sale
            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.ClientId)
                      .IsRequired(); // ClientId obrigatório

                entity.HasOne(s => s.Client)
                      .WithMany(c => c.Sales)
                      .HasForeignKey(s => s.ClientId)
                      .OnDelete(DeleteBehavior.Cascade); // Excluir cliente exclui vendas associadas

                entity.Property(s => s.CreationDate)
                              .HasColumnType("date") // Define o tipo no PostgreSQL como 'date'
                              .IsRequired();

                entity.Property(s => s.TotalValue)
                      .HasColumnType("decimal(18,2)");

            });

            // Configuração da tabela SaleItem
            modelBuilder.Entity<SaleItem>(entity =>
            {
                entity.HasKey(si => si.Id);
                entity.HasOne(si => si.Sale)
                      .WithMany(s => s.SaleItems)
                      .HasForeignKey(si => si.SaleId)
                      .OnDelete(DeleteBehavior.Cascade); // Excluir venda exclui itens associados
                entity.HasOne(si => si.Product)
                      .WithMany()
                      .HasForeignKey(si => si.ProductId)
                      .OnDelete(DeleteBehavior.Restrict); // Produto não pode ser excluído se associado a um item de venda
                entity.Property(si => si.Price)
                      .HasColumnType("decimal(18,2)");
                entity.Property(s => s.CreationDate)
                            .HasColumnType("date") // Define o tipo no PostgreSQL como 'date'
                            .IsRequired();
            });

            // Configuração da tabela MonthlyProfitReport
            modelBuilder.Entity<MonthlyProfitReport>(entity =>
            {
                entity.HasKey(mpr => mpr.Id);
                entity.Property(mpr => mpr.Month)
                      .IsRequired();
                entity.Property(mpr => mpr.TotalProfit)
                      .HasColumnType("decimal(18,2)");
                entity.Property(s => s.CreationDate)
                            .HasColumnType("date") // Define o tipo no PostgreSQL como 'date'
                            .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<MonthlyProfitReport> MonthlyProfitReports { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
