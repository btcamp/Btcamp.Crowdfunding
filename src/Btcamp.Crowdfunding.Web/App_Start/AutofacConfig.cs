using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;
using Btcamp.Crowdfunding.Core.Infrastructure;
using Btcamp.Crowdfunding.Core.Repository;
using Btcamp.Crowdfunding.Core.Services;

namespace Btcamp.Crowdfunding.Web
{
    public class AutofacConfig
    {
        public static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterFilterProvider();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbContextFactory>().As<IDbContextFactory>().InstancePerRequest();
            builder.RegisterInstance<log4net.ILog>(log4net.LogManager.GetLogger("logger"));

            builder.RegisterAssemblyTypes(typeof(AccountRepository).Assembly)
                .Where(n => n.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(UserInfoService).Assembly)
                .Where(n => n.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}