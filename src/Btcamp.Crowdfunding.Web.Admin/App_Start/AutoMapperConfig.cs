using Btcamp.Crowdfunding.Core.Entitys;
using Btcamp.Crowdfunding.Web.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Btcamp.Crowdfunding.Web
{
    public class AutoMapperConfig
    {
        public static void RegisterMapper()
        {
            #region Admin Model Mapper
            
            AutoMapper.Mapper.CreateMap<UserInfo, UserViewModel>();
            AutoMapper.Mapper.CreateMap<UserViewModel, UserInfo>();

            AutoMapper.Mapper.CreateMap<Account, AccountViewModel>();
            AutoMapper.Mapper.CreateMap<AccountViewModel, Account>();

            AutoMapper.Mapper.CreateMap<Address, AddressViewModel>();
            AutoMapper.Mapper.CreateMap<AddressViewModel, Address>();

            AutoMapper.Mapper.CreateMap<Deposit, DepositViewModel>();
            AutoMapper.Mapper.CreateMap<DepositViewModel, Deposit>();

            AutoMapper.Mapper.CreateMap<Withdrawals, WithdrawalsViewModel>();
            AutoMapper.Mapper.CreateMap<WithdrawalsViewModel, Withdrawals>();

            AutoMapper.Mapper.CreateMap<About, AboutViewModel>();
            AutoMapper.Mapper.CreateMap<AboutViewModel, About>();

            AutoMapper.Mapper.CreateMap<SystemSettings, SystemSettingsViewModel>();
            AutoMapper.Mapper.CreateMap<SystemSettingsViewModel, SystemSettings>();

            AutoMapper.Mapper.CreateMap<SystemSettings, SystemSettingsKeyViewModel>();
            AutoMapper.Mapper.CreateMap<SystemSettingsKeyViewModel, SystemSettings>();
            #endregion

            #region Web Model Mapper
            
            #endregion
        }
    }
}