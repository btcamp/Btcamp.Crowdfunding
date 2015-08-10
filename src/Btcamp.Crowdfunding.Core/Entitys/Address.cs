using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Entitys
{
    [Table("Address")]
    public class Address : BaseEntity
    {
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        [Required]
        [StringLength(11)]
        public string PhoneNumber { get; set; }
        public string ZipCode { get; set; }

        [Required]
        [StringLength(128)]
        public string DetailAddress { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        public Guid AccountId { get; set; }
    }
}
