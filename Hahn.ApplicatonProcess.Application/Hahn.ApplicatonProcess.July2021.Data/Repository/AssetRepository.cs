using Hahn.ApplicatonProcess.July2021.Domain;
using Hahn.ApplicatonProcess.July2021.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data
{
    public class AssetRepository : IAssetRepository
    {
        private DBContext context;
        public AssetRepository(DBContext context)
        {
            this.context = context;
        }

        public void DeleteAsset(int Id)
        {
            throw new NotImplementedException();
        }

        public Asset GetAsset(int Id)
        {
            return (Asset)context.UserAsset.Include(x=>x.Asset);           
        }

        public void InsertAsset(UserAsset asset)
        {
            context.Add(asset);
        }

        public void Save()
        {
             context.SaveChanges();
        }

        public void UpdateAsset(UserAsset asset)
        {
            context.Update(asset);
        }
    }
}
