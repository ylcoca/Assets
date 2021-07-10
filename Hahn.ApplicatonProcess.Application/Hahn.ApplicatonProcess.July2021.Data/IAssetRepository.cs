using Hahn.ApplicatonProcess.July2021.Domain;
using Hahn.ApplicatonProcess.July2021.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data
{
    public interface IAssetRepository
    {
        Task<ActionResult<int>> AddUser(User userAsset);
        void InsertAsset(UserAsset asset);
        Asset GetAsset(int Id);
        void DeleteAsset(int Id);
        void UpdateAsset(UserAsset asset);
        void Save();
    }
}
