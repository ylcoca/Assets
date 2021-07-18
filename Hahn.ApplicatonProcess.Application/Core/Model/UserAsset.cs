
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hahn.ApplicatonProcess.July2021.Core.Model
{
    [Table("UserAsset")]
    public class UserAsset
    {
        [Key]
        public int ID { get; set; }
        public Asset Asset { get; set; }
    }
}
