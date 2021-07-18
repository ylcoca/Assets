using Hahn.ApplicatonProcess.July2021.Data.Repository;
using System;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data
{
   public class UnitOfWork :IUnitOfWork
    {
        private readonly DBContext _context;
        IUserAssetRepository _userAssetRepository;

        public UnitOfWork(DBContext context)
        {
            _context = context;
        }

        public IUserAssetRepository UserAssetRepository
        {
            get
            {
                if (_userAssetRepository == null)
                {
                    _userAssetRepository = new UserAssetRepository(_context);
                }
                return _userAssetRepository;
            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
