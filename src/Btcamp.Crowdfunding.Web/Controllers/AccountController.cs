using AutoMapper;
using Btcamp.Crowdfunding.Core.Entitys;
using Btcamp.Crowdfunding.Core.Infrastructure;
using Btcamp.Crowdfunding.Core.Services.Interface;
using Btcamp.Crowdfunding.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Btcamp.Crowdfunding.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService = null;
        private readonly IUnitOfWork unitOfWork = null;
        public AccountController(IAccountService _accountService, IUnitOfWork _unitOfWork)
        {
            this.accountService = _accountService;
            this.unitOfWork = _unitOfWork;
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountLoginViewModel model)
        {
            ResponseModel response = new ResponseModel();
            if (!ModelState.IsValid)
            {
                response.Success = false;
                response.Msg = "请认真检查数据是否复合要求";
                return Json(response);
            }
            if (Session["code"] == null)
            {
                response.Success = false;
                response.Msg = "验证码已过期，请重新获取验证码";
                return Json(response);
            }
            if (Session["code"] != null && !Session["code"].ToString().Equals(model.ValidateCode))
            {
                response.Success = false;
                response.Msg = "验证码输入错误，请重输入验证码";
                return Json(response);
            }
            Account account = accountService.AccountLoginByUserName(model.LoginName, model.Pwd);
            AccountLoginStatusModel loginmodel = new AccountLoginStatusModel();
            loginmodel.ID = account.Id;
            loginmodel.Name = account.Name;
            loginmodel.Email = account.Email;
            FormsAuthentication.SetAuthCookie(JsonConvert.SerializeObject(loginmodel), true);
            response.Success = true;
            response.Msg = "登录成功";
            response.RedirectUrl = "/";
            return Json(response);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AccountRegisterViewModel model)
        {
            ResponseModel response = new ResponseModel();
            if (!ModelState.IsValid)
            {
                response.Success = false;
                response.Msg = "请认真检查数据是否复合要求，请重新注册";
                return Json(response);
            }
            if (Session["code"] == null)
            {
                response.Success = false;
                response.Msg = "验证码已过期，请重新获取验证码";
                return Json(response);
            }
            if (Session["code"] != null && !Session["code"].ToString().Equals(model.ValidateCode))
            {
                response.Success = false;
                response.Msg = "验证码输入错误，请重输入验证码";
                return Json(response);
            }
            #region Register
            Account account = Mapper.Map<Account>(model);
            account.Password = model.Password.ToMd5String();
            account.Sex = Core.CustomEnum.Sex.Male;
            accountService.Add(account);
            unitOfWork.Commit();
            response.Success = true;
            response.Msg = "欢迎您的加入！";
            #endregion

            #region Login
            AccountLoginStatusModel loginmodel = new AccountLoginStatusModel();
            loginmodel.ID = account.Id;
            loginmodel.Name = account.Name;
            loginmodel.Email = account.Email;
            FormsAuthentication.SetAuthCookie(JsonConvert.SerializeObject(loginmodel), true);
            #endregion
            return Json(response);
        }

        public ActionResult Code()
        {
            return File(CreateCheckCodeImage().ToArray(), "image/Gif");
        }

        private System.IO.MemoryStream CreateCheckCodeImage()
        {
            string checkCode = new Random().Next(100000, 999999).ToString();
            Session["code"] = checkCode;
            System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 12.5)) * 2, 45);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器 
                Random random = new Random();
                //清空图片背景色 
                g.Clear(Color.White);
                //画图片的背景噪音线 
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }

                Font font = new System.Drawing.Font("Arial", 28, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(checkCode, font, brush, 2, 2);
                //画图片的前景噪音点 
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线 
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                //Response.ClearContent();
                //Response.ContentType = "image/Gif";
                //Response.BinaryWrite(ms.ToArray());
                return ms;
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
    }

}