using Hahn.ApplicatonProcess.July2021.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data
{
    public interface IUserRepository
    {
        Task<ActionResult<int>> AddUser(User userAsset);
        Task<ActionResult<UserDTO>> GetUser(int id);
    }
}
