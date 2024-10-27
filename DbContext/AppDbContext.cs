using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<UserMaster> UserMasters { get; set; }
    public DbSet<UserClient> UserClients { get; set; }
    public DbSet<Bookings> Bookings { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}