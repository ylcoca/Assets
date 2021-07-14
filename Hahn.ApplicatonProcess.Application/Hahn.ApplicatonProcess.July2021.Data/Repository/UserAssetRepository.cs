using Hahn.ApplicatonProcess.July2021.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var us = context.UserAsset.Include("Asset").Include("Asset.User").Where(ua => ua.ID == Id).FirstOrDefault();
            return us;
        }

        public async Task<ActionResult<int>> InsertUserAsset(UserAsset userAsset)
        {
            context.UserAsset.Add(userAsset);
            int rowsAffected = await context.SaveChangesAsync();
            return rowsAffected;
        }

        public void UpdateUserAsset(UserAsset userAsset)
        {
            context.Entry(userAsset).State = EntityState.Modified;
            context.SaveChanges();
        }

        public bool UserAssetExists(int id) =>
            context.UserAsset.Any(e => e.ID == id);
    }
}
