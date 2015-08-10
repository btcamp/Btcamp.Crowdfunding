using Btcamp.Crowdfunding.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Repository
{
    public class AboutRepository : Infrastructure.RepositoryBase<About>, Infrastructure.IRepository<About>
    {
        public AboutRepository(Infrastructure.IDbContextFactory dbfactory)
            : base(dbfactory)
        {

        }
    }
}
