using AutoMapper;
using Btcamp.Crowdfunding.Core.Entitys;
using Btcamp.Crowdfunding.Core.Infrastructure;
using Btcamp.Crowdfunding.Core.Services.Interface;
using Btcamp.Crowdfunding.Web.Areas.Admin.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Btcamp.Crowdfunding.Web.Areas.Admin.Controllers
{
    public class SystemsettingsController : BaseController
    {
        private readonly ISystemSettingsService _systemSettingsService = null;
        private readonly IUnitOfWork _unitOfWork = null;
        public SystemsettingsController(ISystemSettingsService systemSettingsService, IUnitOfWork unitOfwork)
        {
            this._systemSettingsService = systemSettingsService;
            this._unitOfWork = unitOfwork;
        }
        public override string RedirectUrl
        {
            get { return Request.UrlReferrer == null ? Url.Action("Index") : Request.UrlReferrer.AbsolutePath; }
        }
        // GET: Admin/Systemsettings
        public ActionResult Index(int pageIndex = 1, int pageSize = 20)
        {
            Page page = new Page(pageIndex, pageSize);
            IPagedList<SystemSettings> list = _systemSettingsService.GetPage(page, e => true, e => e.UpdateTime, true);
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Url = RedirectUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Models.SystemSettingsViewModel model)
        {
            ResponseModel response = new ResponseModel();
            response.RedirectUrl = Request["ReturnUlr"];
            SystemSettings settings = Mapper.Map<SystemSettings>(model);
            settings.OperationUser = LoginUser.UserName;
            _systemSettingsService.Add(settings);
            _unitOfWork.Commit();
            response.Success = true;
            response.Msg = "设置成功";
            return Json(response);
        }


        [HttpGet]
        public ActionResult Modify(Guid? id)
        {
            ViewBag.Url = RedirectUrl;
            SystemSettings model = _systemSettingsService.GetById(id.Value);
            SystemSettingsKeyViewModel viewModel = Mapper.Map<SystemSettingsKeyViewModel>(model);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Modify(Models.SystemSettingsViewModel model)
        {
            ResponseModel response = new ResponseModel();
            response.RedirectUrl = Request["ReturnUlr"];
            SystemSettings settings = Mapper.Map<SystemSettings>(model);
            settings.OperationUser = LoginUser.UserName;
            _systemSettingsService.Update(settings);
            _unitOfWork.Commit();
            response.Success = true;
            response.Msg = "修改设置成功";
            return Json(response);
        }

        public ActionResult Del(Guid? Id)
        {
            ResponseModel response = new ResponseModel();
            if (Id != null)
            {
                SystemSettings model = _systemSettingsService.GetById(Id.Value);
                _systemSettingsService.Delete(model);
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

        public ActionResult ValiteKey(string Key)
        {
            SystemSettings model = _systemSettingsService.Get(e => e.Key == Key);
            return Json((model == null), JsonRequestBehavior.AllowGet);
        }

    }
}