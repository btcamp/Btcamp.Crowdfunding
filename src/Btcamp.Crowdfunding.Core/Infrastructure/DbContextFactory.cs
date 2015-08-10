using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Infrastructure
{
    public interface IDbContextFactory
    {
        DbContext DataContext { get; }
    }
    public class DbContextFactory : Disposable, IDbContextFactory
    {
        public DbContext DataContext
        {
            get
            {
                //CallContext：是线程内部唯一的独用的数据槽（一块内存空间）
                //传递DbContext进去获取实例的信息，在这里进行强制转换。
                DbContext dbcontext = CallContext.GetData("dbcontext") as DbContext;
                if (dbcontext == null)
                {
                    dbcontext = new DataContext();
                    if (!dbcontext.Database.Exists())
                    {
                        dbcontext.Database.Initialize(true);
                        dbcontext.SaveChanges();
                    }
                    //保存当前线程的上下文
                    CallContext.SetData("dbcontext", dbcontext);
                }
                return dbcontext;

            }
        }

    }
}
