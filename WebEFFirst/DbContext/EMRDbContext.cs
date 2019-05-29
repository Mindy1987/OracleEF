using System.Data.Entity;
using WebEFFirst.Models;

namespace WebEFFirst.DbContent
{
    public class EMRDbContext : DbContext
    {
        public EMRDbContext() : base("name=EMR")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EMRDbContext>(null);
            modelBuilder.HasDefaultSchema("TEST");
            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<User> Users { get; set; }
    }
}