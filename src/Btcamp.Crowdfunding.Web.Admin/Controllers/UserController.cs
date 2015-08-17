using AutoMapper;
using Newtonsoft.Json;
using PagedList;
using Btcamp.Crowdfunding.Core.Entitys;
using Btcamp.Crowdfunding.Core.Infrastructure;
using Btcamp.Crowdfunding.Core.Services.Interface;
using Btcamp.Crowdfunding.Web.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Btcamp.Crowdfunding.Web.Admin.Controllers
{
    public class UserController : BaseController
    {

        private IUserInfoService _userInfoService = null;
        private IUnitOfWork _unitOfWork = null;
        public UserController(IUnitOfWork unitOfWork, IUserInfoService userInfoService)
        {
            this._userInfoService = userInfoService;
            this._unitOfWork = unitOfWork;
        }
        // GET: Admin/User
        public ActionResult Index(int pageIndex = 1, int pageSize = 20)
        {
            Page page = new Page(pageIndex, pageSize);
            IPagedList<UserInfo> list = _userInfoService.GetPage(page, e => true, e => e.LastLoginDateTime, true);
            return View(list);
        }

        [HttpGet]
        public ActionResult Login(string ReturnUrl = "/Admin")
        {
            Models.UserLoginViewModel model = new UserLoginViewModel();
            model.ReturnUrl = ReturnUrl;
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(Models.UserLoginViewModel model)
        {
            UserInfo user = _userInfoService.UserLoginByEmail(model.Email, model.Password);
            ResponseModel response = new ResponseModel();
            response.Msg = "登陆失败，用户名密码错误";
            if (Request.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
            if (user != null)
            {
                string userinfo = JsonConvert.SerializeObject(user);
                FormsAuthentication.SetAuthCookie(userinfo, false);
                response.Success = true;
                response.Msg = "登陆成功，页面将跳转";
                response.RedirectUrl = model.ReturnUrl;
            }
            return Json(response);
        }


        public ActionResult Logout()
        {
            if (Request.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
            return Redirect(Url.Action("Login"));
        }

        public ActionResult Validemail(string Email)
        {
            UserInfo model = _userInfoService.GetUserByEmail(Email);
            bool result = model == null ? true : false;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Url = RedirectUrl;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(UserViewModel model, HttpPostedFileBase AuthorityUrl)
        {
            ResponseModel response = new ResponseModel();
            response.RedirectUrl = Request["ReturnUlr"];
            try
            {
                string path = string.Empty;
                if (AuthorityUrl != null)
                {
                    path = await SaveImag(AuthorityUrl);
                }
                model.Password = model.Password.ToMd5String();
                UserInfo dbmodel = Mapper.Map<UserInfo>(model);
                dbmodel.AuthorityUrl = path;
                _userInfoService.Add(dbmodel);
                _unitOfWork.Commit();
                response.Success = true;
                response.Msg = "保存成功！请稍后...";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Msg = "保存失败！" + ex.Message;
            }
            return Json(response);
        }
        public ActionResult Del(Guid? Id)
        {
            ResponseModel response = new ResponseModel();
            if (Id != null)
            {
                UserInfo user = _userInfoService.GetById(Id.Value);
                _userInfoService.Delete(user);
                _unitOfWork.Commit();
                response.Success = true;
                response.Msg = "删除成功！";
                response.RedirectUrl = RedirectUrl;
            }
            else
            {
                response.Success = false;
                response.Msg = "无效的请求";
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Unlock(Guid? Id)
        {
            ResponseModel response = new ResponseModel();
            if (Id != null)
            {
                UserInfo user = _userInfoService.GetById(Id.Value);
                user.LoginErrorCount = 0;
                _userInfoService.Update(user);
                _unitOfWork.Commit();
                response.Success = true;
                response.Msg = "解锁成功！";
                response.RedirectUrl = RedirectUrl;
            }
            else
            {
                response.Success = false;
                response.Msg = "无效的请求";
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Modify(Guid? Id)
        {
            ViewBag.Url = RedirectUrl;
            UserInfo user = _userInfoService.GetById(Id.Value);
            UserViewModel model = Mapper.Map<UserInfo, UserViewModel>(user);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Modify(UserViewModel model, HttpPostedFileBase AuthorityUrl)
        {
            ResponseModel response = new ResponseModel();
            response.RedirectUrl = Request["ReturnUlr"];
            try
            {
                string path = string.Empty;
                if (AuthorityUrl != null)
                {
                    path = await SaveImag(AuthorityUrl);
                    model.AuthorityUrl = path;
                }
                model.UpdateTime = DateTime.Now;
                UserInfo dbmodel = Mapper.Map<UserInfo>(model);
                _userInfoService.Update(dbmodel);
                _unitOfWork.Commit();
                response.Success = true;
                response.Msg = "保存成功！请稍后...";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Msg = "保存失败！" + ex.Message;
            }
            return Json(response);
        }

        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            ResponseModel response = new ResponseModel();
            UserInfo user = _userInfoService.GetById(model.Id);
            user.Password = model.Password.ToMd5String();
            _userInfoService.Update(user);
            _unitOfWork.Commit();
            response.Msg = "重置密码成功！";
            response.Success = true;
            response.RedirectUrl = string.Empty;
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public override string RedirectUrl
        {
            get { return Request.UrlReferrer == null ? Url.Action("Index") : Request.UrlReferrer.AbsolutePath; }
        }
    }
}