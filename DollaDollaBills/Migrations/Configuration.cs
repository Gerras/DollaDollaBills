namespace DollaDollaBills.Migrations
{
    using DollaDollaBills.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DollaDollaBills.DAL.DollaDollaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DollaDollaBills.DAL.DollaDollaContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.TotalBills.AddOrUpdate(new TotalBillsModel
            {
                Id = 1,
                Receipts = new System.Collections.Generic.List<Receipt>(),
                Total = 0M
            });
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
