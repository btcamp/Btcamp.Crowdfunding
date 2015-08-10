using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Btcamp.Crowdfunding.Web.Areas.Admin.Models
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            Success = false;
            RedirectUrl = "/";
        }
        public bool Success { get; set; }

        public string Msg { get; set; }

        public string RedirectUrl { get; set; }
    }
}