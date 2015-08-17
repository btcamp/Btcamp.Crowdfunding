using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Btcamp.Crowdfunding.Web.Admin.Models
{
    public class AddressViewModel : BaseViewModel
    {
        [Display(Name = "收货人姓名")]
        [Required(ErrorMessage = "请输入收货人姓名")]
        [StringLength(32)]
        public string Name { get; set; }

        [Display(Name = "收货人电话")]
        [Required(ErrorMessage = "请输入收货人联系电话")]
        [StringLength(11)]
        public string PhoneNumber { get; set; }

        public string ZipCode { get; set; }

        [Display(Name = "详细地址")]
        [Required(ErrorMessage = "请输入收货人详细地址")]
        [StringLength(128)]
        public string DetailAddress { get; set; }

        public Guid AccountId { get; set; }
    }
}