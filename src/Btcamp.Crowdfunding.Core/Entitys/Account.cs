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
        [StringLength(32)]
        public string PhoneNumber { get; set; }

        [StringLength(32)]
        public string Email { get; set; }

        [Required]
        [StringLength(36)]
        public string Password { get; set; }

        [StringLength(36)]
        public string PayPwd { get; set; }

        [StringLength(32)]
        public string Name { get; set; }

        public CustomEnum.Sex Sex { get; set; }

        [StringLength(18)]
        public string IDNumber { get; set; }

        [StringLength(256)]
        public string Address { get; set; }

        [StringLength(256)]
        public string HeaderPath { get; set; }
        /// <summary>
        /// 自我介绍
        /// </summary>
        [StringLength(512)]
        public string Introduction { get; set; }

        public double Amount { get; set; }

        public virtual ICollection<Deposit> Deposits { get; set; }

        public virtual ICollection<Withdrawals> Withdrawals { get; set; }
        public bool IsLock { get; set; }
    }


}
