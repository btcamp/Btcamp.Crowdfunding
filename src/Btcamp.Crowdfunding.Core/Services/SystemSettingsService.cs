using Btcamp.Crowdfunding.Core.Entitys;
using Btcamp.Crowdfunding.Core.Infrastructure;
using Btcamp.Crowdfunding.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Services
{
    public class SystemSettingsService : ServiceBase<SystemSettings>, ISystemSettingsService
    {
        public SystemSettingsService(IRepository<SystemSettings> repository)
            : base(repository)
        {

        }
    }
}
