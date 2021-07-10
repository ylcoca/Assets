using Hahn.ApplicatonProcess.July2021.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain
{
    public interface IUserService
    {
        Task<ActionResult<int>> AddUser(UserDTO userAsset);
    }
}
