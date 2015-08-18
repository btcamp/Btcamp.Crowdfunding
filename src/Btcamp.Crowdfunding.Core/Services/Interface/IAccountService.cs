using Btcamp.Crowdfunding.Core.Entitys;
using Btcamp.Crowdfunding.Core.Infrastructure;
using Btcamp.Crowdfunding.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Services.Interface
{
    public interface IAccountService : IService<Account>
    {
        Account AccountLoginByPhoneNumber(string phoneNumber, string pwd);
        Account AccountLoginByUserName(string userName, string pwd);
        void RegisterAccount(Account account);
    }
}
