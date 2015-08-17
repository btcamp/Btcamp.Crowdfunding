using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Btcamp.Crowdfunding.Web.Admin.Models
{
    public class SystemSettingsKeyViewModel : BaseViewModel
    {
        [Display(Name = "key")]
        [Required(ErrorMessage = "请录入key")]
        [StringLength(32, ErrorMessage = "key关键字过长")]
        public string Key { get; set; }

        [Display(Name = "内容")]
        [Required(ErrorMessage = "请输入设置内容")]
        [StringLength(1024 * 1024)]
        public string Info { get; set; }
        [Display(Name = "Key值描述")]
        [Required(ErrorMessage = "请输入描述信息")]
        [StringLength(1024 * 1024)]
        public string Description { get; set; }
        public string OperationUser { get; set; }
    }
}