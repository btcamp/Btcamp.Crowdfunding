using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Entitys
{
    [Table("Withdrawals")]
    public class Withdrawals : BaseEntity
    {

        public Withdrawals()
        {
            Time = DateTime.Now;
        }

        [Required]
        /// <summary>
        /// 金额
        /// </summary>
        public double Amount { get; set; }
        [Required]
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime Time { get; set; }
        [Required]
        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsAudit { get; set; }
        [Required]
        [StringLength(32)]
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        [Required]
        [StringLength(64)]
        [RegularExpression(@"^\d+$", ErrorMessage = "请输入正确的银行卡号")]
        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankNumber { get; set; }
        [Required]
        [StringLength(64)]
        /// <summary>
        /// 银行
        /// </summary>
        public string Bank { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        public Guid AccountId { get; set; }
    }
}
