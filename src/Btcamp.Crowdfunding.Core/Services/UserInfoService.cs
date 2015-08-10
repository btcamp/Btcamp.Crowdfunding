using Btcamp.Crowdfunding.Core.Entitys;
using Btcamp.Crowdfunding.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Services
{
    public class UserInfoService : ServiceBase<UserInfo>, Interface.IUserInfoService
    {
        //private IUserInfoRepository _userInfoRepository = null;
        public UserInfoService(IRepository<UserInfo> _repository)
            : base(_repository)
        {
        }

        public UserInfo UserLoginByEmail(string email, string pwd)
        {
            string md5pwd = pwd.ToMd5String();
            return base.Get(e => e.Email.ToLower() == email.ToLower() && e.Password == md5pwd);
        }


        public UserInfo GetUserByEmail(string email)
        {
            return base.Get(e => e.Email.ToLower() == email.ToLower());
        }
    }
}
