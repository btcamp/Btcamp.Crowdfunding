using Newtonsoft.Json;
using Btcamp.Crowdfunding.Core.Entitys;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Btcamp.Crowdfunding.Web.Admin.Controllers
{
    public abstract class BaseController : Controller
    {
        log4net.ILog _log = log4net.LogManager.GetLogger("BaseController");
        public UserInfo LoginUser { get; private set; }

        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            base.OnAuthentication(filterContext);
            try
            {
                string action = filterContext.RouteData.Values["action"].ToString();
                if (string.Equals(action, "login", StringComparison.OrdinalIgnoreCase)) { return; }
                if (string.Equals(action, "logout", StringComparison.OrdinalIgnoreCase)) { return; }
                if (Request.IsAuthenticated)
                {
                    UserInfo user = JsonConvert.DeserializeObject<UserInfo>(User.Identity.Name);
                    LoginUser = user;
                    filterContext.HttpContext.Items.Add("currentUser", user);
                }
                else
                {
                    Response.Redirect("/Admin/User/Login");
                    filterContext.Result = new EmptyResult();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/Admin/User/Login");
                filterContext.Result = new EmptyResult();
                throw ex;
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = new EmptyResult();
            _log.Error(filterContext.Exception);
        }

        protected Task<string> SaveImag(HttpPostedFileBase file)
        {
            return Task.Factory.StartNew<string>(() =>
             {
                 string path = string.Empty, imgPath = string.Empty;
                 if (file != null)
                 {
                     try
                     {
                         string extension = Path.GetExtension(file.FileName);
                         string filename = Guid.NewGuid().ToString() + extension;
                         imgPath = Path.Combine("/Content/Image/Admin/", filename);
                         string savePath = Server.MapPath("~/Content/Image/Admin/");
                         if (!Directory.Exists(savePath))
                         {
                             Directory.CreateDirectory(savePath);
                         }
                         path = Path.Combine(savePath, filename);
                         file.SaveAs(path);
                     }
                     catch (Exception ex)
                     {
                         throw ex;
                     }
                 }
                 return imgPath;
             });
        }

        public abstract string RedirectUrl { get; }
    }
}