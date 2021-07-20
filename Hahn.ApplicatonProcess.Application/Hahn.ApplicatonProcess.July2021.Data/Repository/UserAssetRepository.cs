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

        public async Task<int> DeleteUserAsset(UserAsset userAsset)
        {
            context.UserAsset.Remove(userAsset);
            int num =  await context.SaveChangesAsync();
            return num;
        }

        public ActionResult<UserAsset> GetUserAsset(int Id)
        {
            try
            {
                return context.UserAsset.Include("Asset").Include("Asset.User").Where(ua => ua.ID == Id).FirstOrDefault();
            }
            catch (Exception e)
            {

                throw;
            }         
            
        }

        public int InsertUserAsset(UserAsset userAsset)
        {
            try
            {
                context.UserAsset.Add(userAsset);
                int rowsAffected = context.SaveChanges();
                return rowsAffected;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public int UpdateUserAsset(UserAsset userAsset)
        {
            try { 


            context.UserAsset.Update(userAsset);
            int affectedRows = context.SaveChanges();
            return affectedRows;
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
