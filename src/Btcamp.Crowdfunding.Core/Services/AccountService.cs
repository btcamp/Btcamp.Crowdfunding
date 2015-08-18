using Btcamp.Crowdfunding.Core.Entitys;
using Btcamp.Crowdfunding.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Btcamp.Crowdfunding.Core.Services
{
    public class AccountService : ServiceBase<Account>, Interface.IAccountService
    {
        public AccountService(IRepository<Account> repository)
            : base(repository)
        {

        }
        public Account AccountLoginByPhoneNumber(string phoneNumber, string pwd)
        {
            string md5pwd = pwd.ToMd5String();
            return base.Get(e => e.PhoneNumber == phoneNumber && e.Password == md5pwd);
        }

        public void RegisterAccount(Account account)
        {
            base.Add(account);
        }


        public Account AccountLoginByUserName(string userName, string pwd)
        {
            string md5pwd = pwd.ToMd5String();
            return base.Get(e => e.Name == userName && e.Password == md5pwd);
        }
    }
}
