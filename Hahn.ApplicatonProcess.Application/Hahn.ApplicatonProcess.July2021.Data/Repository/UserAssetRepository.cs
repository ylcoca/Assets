using Hahn.ApplicatonProcess.July2021.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data.Repository
{
    public class UserAssetRepository : IUserAssetRepository
    {

        private readonly DBContext context;
        public UserAssetRepository(DBContext context)
        {
            this.context = context;
        }

        public async Task DeleteUserAsset(UserAsset userAsset)
        {
            context.UserAsset.Remove(userAsset);
            await context.SaveChangesAsync();
        }

        public ActionResult<UserAsset> GetUserAsset(int Id)
        {
            try
            {
                return context.UserAsset.Include("Asset").Include("Asset.User").Where(ua => ua.ID == Id).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }

        public async Task<ActionResult<int>> InsertUserAsset(UserAsset userAsset)
        {
            try
            {
                context.UserAsset.Add(userAsset);
                int rowsAffected = await context.SaveChangesAsync();
                return rowsAffected;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void UpdateUserAsset(UserAsset userAsset)
        {
            try
            {
                context.Entry(userAsset).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public bool UserAssetExists(int id) =>
            context.UserAsset.Any(e => e.ID == id);
    }
}
