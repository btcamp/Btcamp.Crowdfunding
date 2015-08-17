using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Btcamp.Crowdfunding.Web.Areas.Admin.Controllers
{
    //[Authorize]
    public class WelComeController : BaseController
    {
        public WelComeController()
        {

        }
        // GET: Admin/WelCome
        public ActionResult Index()
        {
            return View();
        }

        public override string RedirectUrl
        {
            get { return "/Admin"; }
        }
    }
}