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
        void PutUserAsset(UserAsset modifiedUserAsset);
        void DeleteUserAsset(UserAsset userAsset);
        bool UserAssetExists(int id);
    }
}
