using GameStoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStoreMVC.DAL;

public class AppDbContext: DbContext
{
    public DbSet<Game> Games { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }
}
