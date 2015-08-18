using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Btcamp.Crowdfunding.Web.Models;
using Btcamp.Crowdfunding.Core.Entitys;

namespace Btcamp.Crowdfunding.Web
{
    public class AutoMapperConfig
    {
        public static void RegisterMapper()
        {
            #region Web Model Mapper
            AutoMapper.Mapper.CreateMap<Account, AccountRegisterViewModel>();
            AutoMapper.Mapper.CreateMap<AccountRegisterViewModel, Account>();
            #endregion
        }
    }
}