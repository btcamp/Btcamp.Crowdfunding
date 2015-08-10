using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext dbContext;
        public UnitOfWork(IDbContextFactory dbfactory)
        {
            this.dbContext = dbfactory.DataContext;
        }
        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}
