using GusMelfordBooks.Infrastructure.Interfaces;
using GusMelfordBooks.Infrastructure.Models;
using GusMelfordBooks.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;

namespace GusMelfordBooks.Infrastructure;

public sealed class DatabaseContext : DbContext, IDatabaseContext
{
    private readonly DatabaseSettings? _databaseSettings;
    private readonly string _adminEmail;
    private readonly string _adminPassword;
    
    public DbSet<Author>? Authors { get; set; }
    public DbSet<Genre>? Genres { get; set; }
    public DbSet<Publisher>? Publishers { get; set; }
    public DbSet<Book>? Books { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<Invoice>? Invoices { get; set; }

    public DatabaseContext(DatabaseSettings? databaseSettings, string adminEmail, string adminPassword)
    {
        _adminEmail = adminEmail;
        _adminPassword = adminPassword;
        _databaseSettings = databaseSettings;
        Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Genre>().HasIndex(u => u.Name).IsUnique();
        builder.Entity<User>().HasIndex(u => u.Phone).IsUnique();
        builder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        builder.Entity<Publisher>().HasIndex(u => u.Phone).IsUnique();

        InitData(builder);
    }

    private void InitData(ModelBuilder builder)
    {
        Role adminRole = new Role { Name = "Admin" };
        Role userRole = new Role { Name = "User" };
        
        User admin = new User
        {
            Email = _adminEmail,
            Password = _adminPassword,
            RoleId = adminRole.Id,
            FirstName = "Super",
            LastName = "Admin",
            Phone = "+380955016422"
        };

        builder.Entity<Role>().HasData(new List<Role>{ adminRole, userRole});
        builder.Entity<User>().HasData(admin);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            $"Host={_databaseSettings?.Host};" +
            $"Port={_databaseSettings?.Port};" +
            $"Database={_databaseSettings?.Database};" +
            $"Username={_databaseSettings?.Username};" +
            $"Password={_databaseSettings?.Password}");
    }

    public new void Update<TEntity>(TEntity entity)
    {
        (entity as BaseEntity)!.ModifiedOn = DateTime.UtcNow;
        base.Update(entity);
    }

    public new void UpdateRange(IEnumerable<object> entities)
    {
        foreach (object entity in entities)
        {
            Update(entity);
        }
    }
}