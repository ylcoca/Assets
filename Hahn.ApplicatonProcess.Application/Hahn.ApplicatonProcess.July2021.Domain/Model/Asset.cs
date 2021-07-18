using Hahn.ApplicatonProcess.July2021.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hahn.ApplicatonProcess.July2021.Domain
{
    [Table("Asset")]
    public class Asset
    {
        [Key]
        public string assetId { get; set; }
        public string Id { get; set; }
        public int Rank { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double Supply { get; set; }
        public double? MaxSupply { get; set; }
        public double MarketCapUsd { get; set; }
        public double VolumeUsd24Hr { get; set; }
        public double PriceUsd { get; set; }
        public double ChangePercent24Hr { get; set; }
        public double? Vwap24Hr { get; set; }
        public string Explorer { get; set; }
        public User User { get; set; }
    }
}
