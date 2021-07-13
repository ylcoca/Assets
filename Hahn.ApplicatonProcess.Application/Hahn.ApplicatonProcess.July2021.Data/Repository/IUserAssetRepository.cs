using Hahn.ApplicatonProcess.July2021.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data.Repository
{
    public interface IUserAssetRepository
    {
        Task<ActionResult<int>> InsertUserAsset(UserAsset asset);
        Task<ActionResult<UserAsset>> GetUserAsset(int id);
        void UpdateUserAsset(UserAsset userAsset);
        Task DeleteUserAsset(UserAsset userAsset);
        bool UserAssetExists(int id);
    }
}
