using Hahn.ApplicatonProcess.July2021.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext context;
        private UnitOfWork unitOfWork = new UnitOfWork();
        public UserRepository(DBContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<int>> AddUser(User userAsset)
        {
            context.User.Add(userAsset);
            int rowsAffected = await context.SaveChangesAsync();
            return rowsAffected;
        }

        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {            
            return (ActionResult<UserDTO>)await context.User.FindAsync(id);
        }
    }
}
