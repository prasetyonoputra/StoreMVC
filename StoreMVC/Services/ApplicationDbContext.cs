using Microsoft.EntityFrameworkCore;
using StoreMVC.Models;

namespace StoreMVC.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions option) : base(option)
        {
            
        }

        public DbSet<Product> Products{ get; set; }
    }
}
