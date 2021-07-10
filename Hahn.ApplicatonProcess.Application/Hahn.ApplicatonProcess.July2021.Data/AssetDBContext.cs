using Hahn.ApplicatonProcess.July2021.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data
{
    public class AssetDBContext : DbContext
    {
        public AssetDBContext(DbContextOptions<AssetDBContext> options):base(options)
        {

        }
        public DbSet<UserAsset> UserAsset { get; set; }
        public DbSet<User> User { get; set; }
    }
}
