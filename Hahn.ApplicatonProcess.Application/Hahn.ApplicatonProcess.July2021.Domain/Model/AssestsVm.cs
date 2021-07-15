using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Model
{
    public class AssetsVm
    {
        public Asset[] Data { get; set; }
        public long Timestamp { get; set; }
    }
}
