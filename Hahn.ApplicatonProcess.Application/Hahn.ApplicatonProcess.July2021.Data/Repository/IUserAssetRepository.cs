using Hahn.ApplicatonProcess.July2021.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data.Repository
{
    public interface IUserAssetRepository
    {
        int InsertUserAsset(UserAsset asset);
        ActionResult<UserAsset> GetUserAsset(int Id);
        int UpdateUserAsset(UserAsset userAsset);
        Task<int> DeleteUserAsset(UserAsset userAsset);
        bool UserAssetExists(int id);
    }
}
