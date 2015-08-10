using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Services
{
    public class DepositService : Infrastructure.ServiceBase<Entitys.Deposit>, Interface.IDepositService
    {
        public DepositService(Infrastructure.IRepository<Entitys.Deposit> _repository)
            : base(_repository)
        {

        }
    }
}
