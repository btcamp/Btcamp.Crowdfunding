using Btcamp.Crowdfunding.Core.Entitys;
using Btcamp.Crowdfunding.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Repository
{
    public class UserInfoRepository : RepositoryBase<UserInfo>, IRepository<UserInfo>
    {
        public UserInfoRepository(IDbContextFactory dbfactory)
            : base(dbfactory)
        {

        }

    }
}
