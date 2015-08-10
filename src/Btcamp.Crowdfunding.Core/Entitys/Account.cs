using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Entitys
{
    [Table("Account")]
    public class Account : BaseEntity
    {
        [Required]
        [StringLength(32)]
        public string PhoneNumber { get; set; }

        [StringLength(32)]
        public string Email { get; set; }

        [Required]
        [StringLength(36)]
        public string LoginPwd { get; set; }

        [StringLength(32)]
        public string Name { get; set; }

        [StringLength(18)]
        public string IDNumber { get; set; }

        [StringLength(64)]
        public string Bank { get; set; }
        [StringLength(64)]
        public string BankNumber { get; set; }

        /// <summary>
        /// 开户行 分行
        /// </summary>
        [StringLength(64)]
        public string BankBranch { get; set; }


        [StringLength(32)]
        public string MT4Pwd { get; set; }
        [StringLength(32)]
        public string MT4InvestorPwd { get; set; }

        public double Amount { get; set; }

        [StringLength(32)]
        public string MT4Account { get; set; }

        public decimal Interest { get; set; }

        public decimal SumInterest { get; set; }

        public decimal Profit { get; set; }

        public virtual ICollection<Deposit> Deposits { get; set; }

        public virtual ICollection<Withdrawals> Withdrawals { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public bool IsLock { get; set; }
    }
}
