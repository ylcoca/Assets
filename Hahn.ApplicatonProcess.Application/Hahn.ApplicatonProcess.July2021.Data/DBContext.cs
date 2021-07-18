using Hahn.ApplicatonProcess.July2021.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.July2021.Data
{
    public class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options):base(options)
        {

        }
        public DbSet<UserAsset> UserAsset { get; set; }
        public DbSet<Asset> Asset { get; set; }
        public DbSet<User> User { get; set; }
        
    }
}
