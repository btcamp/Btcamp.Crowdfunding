using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Btcamp.Crowdfunding.Web.Areas.Admin.Models
{
    public class AccountViewModel : BaseViewModel
    {
        [Display(Name = "手机号")]
        [Required(ErrorMessage = "请输入手机号")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "请输入正确的手机号")]
        public string PhoneNumber { get; set; }

        [Display(Name = "邮箱地址")]
        [EmailAddress(ErrorMessage = "请输入正确的邮箱地址")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "登陆密码")]
        [Required(ErrorMessage = "请输入登陆密码")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(36, MinimumLength = 6, ErrorMessage = "密码长度只能是6-20位的字符长度")]
        public string LoginPwd { get; set; }

        [Display(Name = "重复密码")]
        [Required(ErrorMessage = "重复登陆密码")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(36, MinimumLength = 6, ErrorMessage = "密码长度只能是6-20位的字符长度")]
        [Compare("LoginPwd", ErrorMessage = "两次密码不一致")]
        public string ConfirmPwd { get; set; }

        [Display(Name = "姓名")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "姓名长度为2-32个字符")]
        public string Name { get; set; }

        [Display(Name = "身份证号")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "请输入合格的身份证号码")]
        public string IDNumber { get; set; }

        [Display(Name = "开户行")]
        [StringLength(64, ErrorMessage = "开户行字段过长")]
        public string Bank { get; set; }

        [Display(Name = "银行卡号")]
        [StringLength(64, ErrorMessage = "银行卡卡号过长")]
        [RegularExpression(@"^\d+$", ErrorMessage = "请输入正确的银行卡号")]
        public string BankNumber { get; set; }

        /// <summary>
        /// 开户行 分行
        /// </summary>
        [StringLength(64, ErrorMessage = "开户行分行字段过长")]
        [Display(Name = "开户行分行")]
        public string BankBranch { get; set; }

        [Display(Name = "MT4登陆密码")]
        [StringLength(32)]
        public string MT4Pwd { get; set; }

        [Display(Name = "MT4投资者密码")]
        [StringLength(32)]
        public string MT4InvestorPwd { get; set; }

        [Display(Name = "余额")]
        public double Amount { get; set; }

        [Display(Name = "MT4账户")]
        public string MT4Account { get; set; }

        [Display(Name = "昨日利息")]
        public decimal Interest { get; set; }

        [Display(Name = "总利息")]
        public decimal SumInterest { get; set; }

        [Display(Name = "昨日盈利")]
        public decimal Profit { get; set; }

        [Display(Name = "是否锁定")]
        public bool IsLock { get; set; }
    }
}