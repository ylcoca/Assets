using Hahn.ApplicatonProcess.July2021.Data.Repository;

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
        { //locking
            get
            {
                if (_userAssetRepository == null)
                {
                    _userAssetRepository = new UserAssetRepository(_context);
                }
                return _userAssetRepository;
            }
        }
        public void Commit()
        { _context.SaveChanges(); }

        public void Rollback()
        { _context.Dispose(); }
    }
}
