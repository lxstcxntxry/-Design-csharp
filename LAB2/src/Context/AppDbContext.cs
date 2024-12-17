namespace bookshop;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql
            ("Host=localhost;" +
            "Database=BookShop;" +
            "Username=postgres;" +
            "Password=1");
    }
}
