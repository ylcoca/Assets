using Hahn.ApplicatonProcess.July2021.Domain;
using Hahn.ApplicatonProcess.July2021.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hahn.ApplicatonProcess.July2021.Data
{
    class AssetRepository : IAssetRepository
    {
        private AssetDBContext context;
        public AssetRepository(AssetDBContext context)
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
