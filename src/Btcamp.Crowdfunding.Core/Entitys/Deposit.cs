using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Entitys
{
    [Table("Deposit")]
    public class Deposit : BaseEntity
    {

        public double Amount { get; set; }

        public DateTime Time { get; set; }

        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsAudit { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        [StringLength(36)]
        public Guid AccountId { get; set; }
    }
}
