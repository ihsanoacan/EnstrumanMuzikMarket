using DAL.Entity;
using System.Data.Entity;

namespace DAL.Context
{
    public class ProjectContext:DbContext

    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "server=.;database=EnstrumanMuzikMarketDB;uid=sa;pwd=123";
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address>Addresses { get; set; }
        public DbSet<City> Cities  { get; set; }
        public DbSet<District> Districts { get; set; }
        //public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            
            base.OnModelCreating(modelBuilder);
        }

    }
}
