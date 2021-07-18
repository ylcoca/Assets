using Hahn.ApplicatonProcess.July2021.Core.Model;
using Hahn.ApplicatonProcess.July2021.Data;
using Hahn.ApplicatonProcess.July2021.Domain.Validators;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Hahn.ApplicatonProcess.July2021.Domain.BussinessLogic
{
    public class Service : IService
    {
        private readonly IUnitOfWork _unitOfWork;
        UserValidator validator;
        private readonly DBContext _context;

        public Service(DBContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            //unitOfWork = new UnitOfWork(_context);
            _unitOfWork = unitOfWork;
        }
        public ValidationResult AddUserAsset(UserAsset userAsset)
        {
            try
            {
                validator = new();
                ValidationResult results = validator.Validate(userAsset);

                if (results.IsValid)
                {
                    _unitOfWork.UserAssetRepository.InsertUserAsset(userAsset);
                    return null;
                }
                return results;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public ActionResult<UserAsset> GetUserAsset(int id)
        {            
            return _unitOfWork.UserAssetRepository.GetUserAsset(id);
        }

        public void PutUserAsset(UserAsset modifiedUserAsset)
        {
            _unitOfWork.UserAssetRepository.UpdateUserAsset(modifiedUserAsset);
        }

        public void DeleteUserAsset(UserAsset userAsset)
        {
            _unitOfWork.UserAssetRepository.DeleteUserAsset(userAsset);
        }

        public bool UserAssetExists(int id)
        {
            return _unitOfWork.UserAssetRepository.UserAssetExists(id);
        }
    }
}
