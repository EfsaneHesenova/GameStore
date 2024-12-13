using GameStoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStoreMVC.DAL;

public class AppDbContext: DbContext
{
    public DbSet<Game> Games { get; set; }
    public DbSet<GameComment> Comments { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
       
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<GameComment>()
            .HasOne(g=> g.Game)
            .WithMany(g => g.GameComments)
            .HasForeignKey(g => g.GameId)
            .OnDelete(DeleteBehavior.Restrict);

            
    }
}
