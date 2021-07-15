using Hahn.ApplicatonProcess.July2021.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hahn.ApplicatonProcess.July2021.Domain
{
    [Table("Asset")]
    public class Asset
    {
        [Key]
        public string Id { get; set; }
        public string Rank { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Supply { get; set; }
        public string MaxSupply { get; set; }
        public string MarketCapUsd { get; set; }
        public string VolumeUsd24Hr { get; set; }
        public string PriceUsd { get; set; }
        public string ChangePercent24Hr { get; set; }
        public string Vwap24Hr { get; set; }
        public string Explorer { get; set; }
        public User User { get; set; }
    }
}
