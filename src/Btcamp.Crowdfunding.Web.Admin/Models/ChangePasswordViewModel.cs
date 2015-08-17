using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Btcamp.Crowdfunding.Web.Admin.Models
{
    public class ChangePasswordViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "登陆密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "请输入登陆密码")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "密码长度只能是6-20位的字符长度")]
        public string Password { get; set; }

        [Display(Name = "确认密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "请输入确认密码")]
        [Compare("Password", ErrorMessage = "两次密码不一致")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "密码长度只能是6-20位的字符长度")]
        public string ConfirmPassword { get; set; }
    }
}