namespace AccountValidationService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AccountValidationService.Models;

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

            context.Accounts.AddOrUpdate(
                x => x.accountId,
                new Account { accountId = 1, Username ="d.petkov87", Email = "d.petkov87@gmail.com", Iban = "BG80BNBG96611020345678" },
                new Account { accountId = 2, Username = "mariana_ilieva_88", Email = "milieva@abv.bg", Iban = "BG80BNBG96611020345679" },
                new Account { accountId = 3, Username = "mr_millionaire", Email = "giliev222@tu-sofia.bg", Iban = "BG80BNBG96611020345680" }

                );
        }
    }
}
