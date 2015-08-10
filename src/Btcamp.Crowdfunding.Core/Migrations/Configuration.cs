namespace Btcamp.Crowdfunding.Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Btcamp.Crowdfunding.Core.Infrastructure.DataContext>
    {
        public Configuration()
        {
#if DEBUG
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
#else
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
#endif
        }

        protected override void Seed(Btcamp.Crowdfunding.Core.Infrastructure.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
