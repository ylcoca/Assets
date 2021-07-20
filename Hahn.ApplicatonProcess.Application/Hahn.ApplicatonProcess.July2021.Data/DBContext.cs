using Hahn.ApplicatonProcess.July2021.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
        public virtual DbSet<UserAsset> UserAsset { get; set; }
        public virtual DbSet<Asset> Asset { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
