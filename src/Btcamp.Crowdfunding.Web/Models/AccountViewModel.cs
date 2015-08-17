using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Btcamp.Crowdfunding.Web.Models
{
    public class AccountLoginViewModel
    {
        public string LoginName { get; set; }


        public string Pwd { get; set; }
    }
    public class AccountRegisterViewModel
    {
        [Required(ErrorMessage = "请输入 邮箱")]
        [RegularExpression(@"^.+@.+\..+$", ErrorMessage = "请输入有效的邮箱")]
        [System.Web.Mvc.Remote("ValidateEmail", "Account", ErrorMessage = "该邮箱已被注册")]
        public string Email { get; set; }

        [Required(ErrorMessage = "请输入用户名")]
        [System.Web.Mvc.Remote("ValidateUserName", "Account", ErrorMessage = "该用户名已被注册")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "请输入密码")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "请输入有效的密码字符长度，6-20位字符")]
        public string Password { get; set; }

        [Required(ErrorMessage = "请输入确认密码")]
        [Compare("Password", ErrorMessage = "两次密码不一致")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "请输入验证码")]
        public string ValidateCode { get; set; }
    }
}