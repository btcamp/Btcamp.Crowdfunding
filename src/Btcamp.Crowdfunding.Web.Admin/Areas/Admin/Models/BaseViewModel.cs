using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Btcamp.Crowdfunding.Web.Areas.Admin.Models
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            UpdateTime = DateTime.Now;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}