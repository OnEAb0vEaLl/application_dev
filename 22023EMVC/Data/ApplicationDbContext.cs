using _22023EMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace _22023EMVC.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public  DbSet<Product> Products { get; set; }
    }
}
