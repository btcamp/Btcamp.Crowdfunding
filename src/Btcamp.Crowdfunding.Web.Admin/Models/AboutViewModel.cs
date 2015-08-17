using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Btcamp.Crowdfunding.Web.Admin.Models
{
    public class AboutViewModel : BaseViewModel
    {
        [Display(Name = "客服电话")]
        [Required(ErrorMessage = "请输入客服电话")]
        [StringLength(11)]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "请输入正确的手机号")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// QQ官方交流群  
        /// </summary>
        [Display(Name = "QQ官方交流群")]
        [Required(ErrorMessage = "请输入QQ官方群号")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "请输入正确的QQ号")]
        public string QQGroupNumber { get; set; }

        /// <summary>
        /// 微信公众号
        /// </summary>
        [Display(Name = "微信公众号")]
        [Required(ErrorMessage = "请输入微信公众号")]
        public string WeChatNumber { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [Display(Name = "版本号")]
        [Required(ErrorMessage = "请输入当前版本号")]
        public string VersionNumber { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        [Display(Name = "图片地址")]
        [DataType(DataType.Upload)]
        public string PhotoUrl { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Display(Name = "显示内容")]
        [Required(ErrorMessage = "请输入显示内容")]
        [StringLength(1024 * 1024)]
        public string Contents { get; set; }
    }
}