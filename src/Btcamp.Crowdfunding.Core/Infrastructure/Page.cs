using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Infrastructure
{
    public class Page
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public Page()
        {
            PageIndex = 1;
            PageSize = 10;
        }
        public Page(int pageindex, int pagesize)
        {
            this.PageSize = pagesize;
            this.PageIndex = pageindex;
        }

        public int Skip
        {
            get { return (PageIndex - 1) * PageSize; }
        }
    }
}
