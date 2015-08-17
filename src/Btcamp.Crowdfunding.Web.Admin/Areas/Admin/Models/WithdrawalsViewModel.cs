using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Btcamp.Crowdfunding.Web.Areas.Admin.Models
{
    public class WithdrawalsViewModel : BaseViewModel
    {
        public double Amount { get; set; }

        public DateTime Time { get; set; }

        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsAudit { get; set; }
        public Guid AccountId { get; set; }
    }
}