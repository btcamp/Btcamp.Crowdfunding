using AutoMapper;
using Btcamp.Crowdfunding.Core.Entitys;
using Btcamp.Crowdfunding.Core.Infrastructure;
using Btcamp.Crowdfunding.Core.Services.Interface;
using Btcamp.Crowdfunding.Web.Areas.Admin.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Btcamp.Crowdfunding.Web.Areas.Admin.Controllers
{
    public class AboutController : BaseController
    {
        private IAboutService _aboutService = null;
        private IUnitOfWork _unitOfWork = null;
        public AboutController(IUnitOfWork unitOfWork, IAboutService aboutService)
        {
            this._aboutService = aboutService;
            this._unitOfWork = unitOfWork;
        }
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            Page page = new Page(pageIndex, pageSize);
            IPagedList<About> list = _aboutService.GetPage(page, e => true, e => e.Id, true);
            return View(list);

        }
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Url = RedirectUrl;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(AboutViewModel model, HttpPostedFileBase PhotoUrl)
        {
            ResponseModel response = new ResponseModel();
            response.RedirectUrl = Request["ReturnUlr"];
            try
            {
                string path = string.Empty;
                if (PhotoUrl != null)
                {
                    path = await SaveImag(PhotoUrl);
                }
                About dbmodel = Mapper.Map<About>(model);
                dbmodel.PhotoUrl = path;
                _aboutService.Add(dbmodel);
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

        [HttpGet]
        public ActionResult Modify(Guid? Id)
        {
            ViewBag.Url = RedirectUrl;
            About about = _aboutService.GetById(Id.Value);
            AboutViewModel model = Mapper.Map<About, AboutViewModel>(about);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Modify(AboutViewModel model, HttpPostedFileBase PhotoUrl)
        {
            ResponseModel response = new ResponseModel();
            response.RedirectUrl = Request["ReturnUlr"];
            try
            {
                string path = string.Empty;
                if (PhotoUrl != null)
                {
                    path = await SaveImag(PhotoUrl);
                    model.PhotoUrl = path;
                }
                else
                {
                    model.PhotoUrl = Request.Form["PhotoUrl"];
                }
                model.UpdateTime = DateTime.Now;
                About dbmodel = Mapper.Map<About>(model);
                _aboutService.Update(dbmodel);
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
                About about = _aboutService.GetById(Id.Value);
                _aboutService.Delete(about);
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

        public override string RedirectUrl
        {
            get { return Request.UrlReferrer == null ? Url.Action("Index") : Request.UrlReferrer.AbsolutePath; }
        }
    }
}