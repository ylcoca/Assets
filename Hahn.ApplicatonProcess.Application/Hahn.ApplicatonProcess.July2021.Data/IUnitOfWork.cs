using Hahn.ApplicatonProcess.July2021.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data
{
    interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
