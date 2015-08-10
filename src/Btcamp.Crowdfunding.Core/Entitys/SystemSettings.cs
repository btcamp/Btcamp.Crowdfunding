using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Entitys
{
    [Table("SystemSettings")]
    public class SystemSettings : BaseEntity
    {
        [Required]
        [StringLength(32)]
        public string Key { get; set; }
        [Required]
        [StringLength(1024 * 1024)]
        public string Info { get; set; }
        [StringLength(1024 * 1024)]
        public string Description { get; set; }
        public string OperationUser { get; set; }
    }
}
