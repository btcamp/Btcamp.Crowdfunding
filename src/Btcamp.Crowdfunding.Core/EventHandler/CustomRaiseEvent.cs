using Btcamp.Crowdfunding.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.EventHandler
{
    public class CustomRaiseEvent
    {
        public static void RaiseAccountRegister(Account account)
        {
            if (AccountRegisterEvent != null)
            {
                AccountRegisterEvent(null, account);
            }
        }
        public static event EventHandler<Account> AccountRegisterEvent;

    }
}
