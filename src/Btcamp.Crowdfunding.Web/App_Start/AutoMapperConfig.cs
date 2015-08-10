using Btcamp.Crowdfunding.Core.Entitys;
using Admin = Btcamp.Crowdfunding.Web.Areas.Admin.Models;
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
            AutoMapper.Mapper.CreateMap<UserInfo, Admin.UserViewModel>();
            AutoMapper.Mapper.CreateMap<Admin.UserViewModel, UserInfo>();

            AutoMapper.Mapper.CreateMap<Account, Admin.AccountViewModel>();
            AutoMapper.Mapper.CreateMap<Admin.AccountViewModel, Account>();

            AutoMapper.Mapper.CreateMap<Address, Admin.AddressViewModel>();
            AutoMapper.Mapper.CreateMap<Admin.AddressViewModel, Address>();

            AutoMapper.Mapper.CreateMap<Deposit, Admin.DepositViewModel>();
            AutoMapper.Mapper.CreateMap<Admin.DepositViewModel, Deposit>();

            AutoMapper.Mapper.CreateMap<Withdrawals, Admin.WithdrawalsViewModel>();
            AutoMapper.Mapper.CreateMap<Admin.WithdrawalsViewModel, Withdrawals>();

            AutoMapper.Mapper.CreateMap<About, Admin.AboutViewModel>();
            AutoMapper.Mapper.CreateMap<Admin.AboutViewModel, About>();

            AutoMapper.Mapper.CreateMap<SystemSettings, Admin.SystemSettingsViewModel>();
            AutoMapper.Mapper.CreateMap<Admin.SystemSettingsViewModel, SystemSettings>();

            AutoMapper.Mapper.CreateMap<SystemSettings, Admin.SystemSettingsKeyViewModel>();
            AutoMapper.Mapper.CreateMap<Admin.SystemSettingsKeyViewModel, SystemSettings>();
            #endregion

            #region Web Model Mapper
            
            #endregion
        }
    }
}