using Btcamp.Crowdfunding.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Services
{
    public class AboutService : Infrastructure.ServiceBase<About>, Interface.IAboutService
    {
        public AboutService(Infrastructure.IRepository<About> repository)
            : base(repository)
        {

        }
    }
}
