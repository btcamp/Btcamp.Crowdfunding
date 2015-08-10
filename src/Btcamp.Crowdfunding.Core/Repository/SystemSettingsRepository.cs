using Btcamp.Crowdfunding.Core.Entitys;
using Btcamp.Crowdfunding.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Repository
{
    public class SystemSettingsRepository : Infrastructure.RepositoryBase<SystemSettings>, Infrastructure.IRepository<SystemSettings>
    {
        public SystemSettingsRepository(IDbContextFactory dbfactory)
            : base(dbfactory)
        {

        }
    }
}
