using GenFu;
using LeaderBoardAPI.Entities;
using LeaderBoardAPI.Helpers.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LeaderBoardAPI.Helpers;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<League>().HasMany(s => s.Users);
        
        modelBuilder.Entity<League>().Navigation(l => l.Users).AutoInclude();
        //modelBuilder.ApplyConfiguration(new UserConfiguration());
        //modelBuilder.ApplyConfiguration(new LeagueConfiguration());
    }

    public DbSet<User> Users { get; set; }
    public DbSet<League> Leagues { get; set; }
}