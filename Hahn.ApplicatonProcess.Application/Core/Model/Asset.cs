using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hahn.ApplicatonProcess.July2021.Core.Model
{
    [Table("Asset")]
    public class Asset
    {
        [Key]
        public int Id { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }
        public double Supply { get; set; }
        public double? MaxSupply { get; set; }
        public double MarketCapUsd { get; set; }
        public double VolumeUsd24Hr { get; set; }
        public double PriceUsd { get; set; }
        public User User { get; set; }
    }
}
