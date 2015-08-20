using Btcamp.Crowdfunding.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Btcamp.Crowdfunding.Web.Controllers
{
    public class BaseController : Controller
    {
        public AccountLoginStatusModel LoginAccount { get; private set; }

        protected override void OnAuthentication(System.Web.Mvc.Filters.AuthenticationContext filterContext)
        {
            base.OnAuthentication(filterContext);
            try
            {
                string action = filterContext.RouteData.Values["action"].ToString();
                string controller = filterContext.RouteData.Values["controller"].ToString();
                if (string.Equals(controller, "home", StringComparison.OrdinalIgnoreCase) && string.Equals(action, "index", StringComparison.OrdinalIgnoreCase))
                {
                    if (Request.IsAuthenticated)
                    {
                        AccountLoginStatusModel account = JsonConvert.DeserializeObject<AccountLoginStatusModel>(User.Identity.Name);
                        filterContext.HttpContext.Items.Add("currentUser", account);
                        LoginAccount = account;
                    }
                    return;

                }
                if (string.Equals(action, "login", StringComparison.OrdinalIgnoreCase)) { return; }
                if (string.Equals(action, "logout", StringComparison.OrdinalIgnoreCase)) { return; }
                if (string.Equals(action, "register", StringComparison.OrdinalIgnoreCase)) { return; }
                if (string.Equals(action, "ValideEmail", StringComparison.OrdinalIgnoreCase)) { return; }
                if (string.Equals(action, "code", StringComparison.OrdinalIgnoreCase)) { return; }
                if (Request.IsAuthenticated)
                {
                    AccountLoginStatusModel account = JsonConvert.DeserializeObject<AccountLoginStatusModel>(User.Identity.Name);
                    filterContext.HttpContext.Items.Add("currentUser", account);
                    LoginAccount = account;
                }
                else
                {
                    Response.Redirect("/Account/Login");
                    filterContext.Result = new EmptyResult();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/Account/Login");
                filterContext.Result = new EmptyResult();
                throw ex;
            }
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            log4net.ILog log = log4net.LogManager.GetLogger(filterContext.HttpContext.Request.Url.AbsolutePath);
            log.Error(filterContext.Exception);
            filterContext.Result = new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new ResponseModel() { Msg = "系统繁忙，请稍后再试！" }
            };
        }
    }
}