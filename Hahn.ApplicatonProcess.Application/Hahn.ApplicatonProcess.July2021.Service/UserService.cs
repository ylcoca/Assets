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
        IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<ActionResult<int>> AddUser(User userAsset)
        {
           return _repository.AddUser(userAsset);
        }

        public Task<ActionResult<UserDTO>> GetUser(int id)
        {
            return _repository.GetUser(id);
        }
    }
}
