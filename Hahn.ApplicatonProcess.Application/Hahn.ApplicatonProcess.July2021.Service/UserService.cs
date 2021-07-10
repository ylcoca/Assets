using Hahn.ApplicatonProcess.July2021.Data;
using Hahn.ApplicatonProcess.July2021.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain
{
    public class UserService : IUserService
    {
        IAssetRepository _repository;
        public UserService(IAssetRepository repository)
        {
            _repository = repository;
        }

        public Task<ActionResult<int>> AddUser(UserDTO userAsset)
        {
           return _repository.AddUser(userAsset);
        }
    }
}
