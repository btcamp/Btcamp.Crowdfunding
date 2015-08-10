using Btcamp.Crowdfunding.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {
            //this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deposit>()
                .HasRequired(d => d.Account)
                .WithMany(a => a.Deposits)
                .HasForeignKey(d => d.AccountId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Withdrawals>()
                .HasRequired(w => w.Account)
                .WithMany(a => a.Withdrawals)
                .HasForeignKey(d => d.AccountId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasRequired(a => a.Account)
                .WithMany(a => a.Address)
                .HasForeignKey(a => a.AccountId)
                .WillCascadeOnDelete(false);
        }

        public IDbSet<UserInfo> UserInfo { get; set; }
        public IDbSet<Account> Account { get; set; }

        public IDbSet<Address> Address { get; set; }


        public IDbSet<Deposit> Deposit { get; set; }
        public IDbSet<Withdrawals> Withdrawals { get; set; }

        public IDbSet<SystemSettings> SystemSettings { get; set; }

        public IDbSet<About> About { get; set; }
    }
}
