using System;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data
{
   public class UnitOfWork : IDisposable
    {
        private readonly DBContext context = new();
        IUserRepository _repository;

        public IUserRepository UserRepository
        {
            get
            {
                if (_repository == null)
                {
                    _repository = new UserRepository(context);
                }
                return _repository;
            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync()
        {
           return await context.SaveChangesAsync();
        }
    }
}
