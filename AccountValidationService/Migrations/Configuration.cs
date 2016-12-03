namespace AccountValidationService.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AccountValidationService.Models.AccountValidationServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AccountValidationService.Models.AccountValidationServiceContext context)
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

            

            context.Accounts.AddOrUpdate(x => x.Id,
                new Account() { Id = 1, Email = "ivanivano@gmail.com", Iban = "BG80BNBG96611020345678", Username = "i.ivanov" },
                new Account() { Id = 2, Email = "p.draganov@yahoo.com", Iban = "BG80BNBG96611020345679", Username = "pdraganov" },
                new Account() { Id = 3, Email = "lubo@abv.bg", Iban = "BG80BNBG96611020345658", Username = "lubo93" }
                );
        }
    }
}
