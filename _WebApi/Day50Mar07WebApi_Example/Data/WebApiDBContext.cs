using Microsoft.EntityFrameworkCore;
using Day50WebApi_Example.Models;
namespace Day50WebApi_Example.Data
{
    public class WebApiDBContext: DbContext
    {
        public WebApiDBContext(DbContextOptions options):base(options) 
        { 
        }

        public DbSet<Employee> employees { get; set; }
    }
}
