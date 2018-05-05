using Statement.Core.DomainModels;
using System.Data.Entity;

namespace Statement.Data
{
    public class StatementDbContext : DbContext
    {
        public readonly object MaterialFactor;

        public StatementDbContext() : base("StatementConnection")
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Factor> Factors { get; set; }
        public DbSet<MaterialFactor> MaterialFactors { get; set; }

    }
}
