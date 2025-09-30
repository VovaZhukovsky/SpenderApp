using Microsoft.EntityFrameworkCore;
using Spender.DAL.Models;

namespace Spender.DAL;

public class ApplicationContext: DbContext
{
    public DbSet<Category> Categories {get; set;}
    public DbSet<Client> Clients {get; set;}
    public DbSet<Currency> Currencies {get; set;}
    public DbSet<Expense> Expenses {get; set;}
    public DbSet<Income> Incomes {get; set;}

    public ApplicationContext()
    {
        
    }
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=spenderdb;Username=postgres;Password=12345");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Expense>(entity =>
        {
            entity.Property(e => e.Amount)
                .HasColumnType("money");
        });
        modelBuilder.Entity<Income>(entity =>
        {
            entity.Property(e => e.Amount)
                .HasColumnType("money");
        });
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasIndex(c => c.Mail)
                .IsUnique();
        });
        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasIndex(e => e.Name)
                .IsUnique();
        });
    }
}