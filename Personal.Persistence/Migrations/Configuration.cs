using Personal.Entities;

namespace Personal.Persistence.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Personal.Persistence.HrDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Personal.Persistence.HrDbContext";
        }

        protected override void Seed(Personal.Persistence.HrDbContext context)
        {
            var locationList = new List<Location>()
            {
                new Location()
                {
                    City = "Arad",
                    StreetAddress = "1234",
                    StateProvince = "1111",
                    PostalCode = "1111"
                }, new Location()
                {
                    City = "Oradea",
                    StreetAddress = "1234",
                    StateProvince = "2222",
                    PostalCode = "222"
                }, new Location()
                {
                    City = "Oradea",
                    StreetAddress = "444",
                    StateProvince = "444",
                    PostalCode = "444"
                }
            };

            foreach (var location in locationList)
            {
                context.Locations.AddOrUpdate(x => x.City, location);
            }
        }
    }
}
