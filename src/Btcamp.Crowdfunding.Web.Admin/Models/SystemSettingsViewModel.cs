using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Btcamp.Crowdfunding.Web.Admin.Models
{
    public class SystemSettingsViewModel : BaseViewModel
    {
        [Display(Name = "key")]
        [Required(ErrorMessage = "请录入key")]
        [StringLength(32, ErrorMessage = "key关键字过长")]
        [System.Web.Mvc.Remote("ValiteKey","SystemSettings",ErrorMessage="请更换Key，已存在.")]
        public string Key { get; set; }

        [Display(Name = "内容")]
        [Required(ErrorMessage = "请输入设置内容")]
        [StringLength(1024 * 1024)]
        public string Info { get; set; }
        [Display(Name = "Key值描述")]
        [StringLength(1024 * 1024)]
        public string Description { get; set; }
        public string OperationUser { get; set; }
    }
}