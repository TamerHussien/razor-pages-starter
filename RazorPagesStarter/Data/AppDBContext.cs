using Microsoft.EntityFrameworkCore;
using RazorPagesStarter.Models;

namespace RazorPagesStarter.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Book> Books => Set<Book>();
}
