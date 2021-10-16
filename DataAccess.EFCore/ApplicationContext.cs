using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccesss.EFCore.Entities
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
