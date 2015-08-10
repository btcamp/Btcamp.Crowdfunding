using Btcamp.Crowdfunding.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Repository
{
    public class AccountRepository : Infrastructure.RepositoryBase<Account>, Infrastructure.IRepository<Account>
    {
        public AccountRepository(Infrastructure.IDbContextFactory dbfactory)
            : base(dbfactory)
        {

        }
    }
}
