using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Btcamp.Crowdfunding.Web.Areas.Admin.Models
{
    public class UserViewModel : BaseViewModel
    {
        public UserViewModel()
        {
            CreateDateTime = DateTime.Now;
            LastLoginDateTime = DateTime.Now;
        }
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "请输入用户姓名")]
        public string UserName { get; set; }

        [Display(Name = "登陆邮箱")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "请输入登陆邮箱")]
        [EmailAddress(ErrorMessage = "请输入正确的邮箱地址")]
        [System.Web.Mvc.Remote("Validemail", "User", ErrorMessage = "邮箱以重复，请重新输入")]
        public string Email { get; set; }

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

        [Display(Name = "联系方式")]
        [Required(ErrorMessage = "请输入手机号码")]
        [Phone(ErrorMessage = "请输入正确手机号码")]
        public string PhoneNumber { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime LastLoginDateTime { get; set; }

        public int LoginErrorCount { get; set; }

        [Display(Name = "用户头像")]
        [DataType(DataType.Upload)]
        public string AuthorityUrl { get; set; }
    }
}