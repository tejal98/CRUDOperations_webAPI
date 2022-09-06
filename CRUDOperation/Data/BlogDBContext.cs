using CRUDOperation.Models;
using Microsoft.EntityFrameworkCore;


namespace CRUDOperation.Data
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> options)
            : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
    }
}
