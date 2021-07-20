using FluentValidation.Results;
using Hahn.ApplicatonProcess.July2021.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.BussinessLogic
{
    public interface IService
    {
        ValidationResult AddUserAsset(UserAsset userAsset);
        ActionResult<UserAsset> GetUserAsset(int id);
        int PutUserAsset(UserAsset modifiedUserAsset);
        Task<int> DeleteUserAsset(UserAsset userAsset);
        bool UserAssetExists(int id);
    }
}
