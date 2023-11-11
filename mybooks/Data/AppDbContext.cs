using Microsoft.EntityFrameworkCore;
using mybooks.Data.Models;

namespace mybooks.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }

        public DbSet<Book> Books { get; set; }
    }
}
