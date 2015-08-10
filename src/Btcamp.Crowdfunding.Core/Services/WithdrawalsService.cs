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
    public class WithdrawalsService : ServiceBase<Withdrawals>, IWithdrawalsService
    {
        public WithdrawalsService(IRepository<Withdrawals> _repository)
            : base(_repository)
        {

        }
    }
}
