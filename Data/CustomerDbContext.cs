using Microsoft.EntityFrameworkCore;
using CustomerApi.Models.Entities;

namespace CustomerApi.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

        public DbSet<CustomerMaster> CustomerMasters { get; set; }
    }
}
