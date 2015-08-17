using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Btcamp.Crowdfunding.Web.Areas.Admin.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "请输入登陆邮箱")]
        [RegularExpression(@"^.+@.+\..+$", ErrorMessage = "请输入正确的邮箱地址")]
        public string Email { get; set; }
        [Required(ErrorMessage = "请输入登陆密码")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }


    }
}