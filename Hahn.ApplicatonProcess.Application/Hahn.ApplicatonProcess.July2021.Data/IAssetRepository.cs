using Hahn.ApplicatonProcess.July2021.Domain;
using Hahn.ApplicatonProcess.July2021.Domain.Model;

namespace Hahn.ApplicatonProcess.July2021.Data
{
    public interface IAssetRepository
    {
        void InsertAsset(UserAsset asset);
        Asset GetAsset(int Id);
        void DeleteAsset(int Id);
        void UpdateAsset(UserAsset asset);
        void Save();
    }
}
