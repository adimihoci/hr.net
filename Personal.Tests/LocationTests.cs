using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal.Entities;
using Personal.Persistence;
using Shouldly;

namespace Personal.Tests
{
    public class LocationTests
    {
        public void CanAddLocation()
        {
            using(var context = new HrDbContext())
            {
                

                var location = new Location
                {
                    City = "City",
                    PostalCode = "0.0076",
                    StateProvince = "dsad",
                    StreetAddress = "das"
                };

                context.Locations.Add(location);
                context.SaveChanges();

                var retrievedLocation = context.Locations.Single((l => l.LocationId == location.LocationId));
                retrievedLocation.ShouldBe(location);
            }
            ;

            
        }

        public void QuerableVsEnumrable()
        {
            using (var context = new HrDbContext())
            {
                var locations = context.Locations.Where(x => x.City.StartsWith("O")).OrderBy(o => o.PostalCode);
                var locationList = locations.ToList().Where(x => x.StateProvince.Contains("1"));
            }   
        }
    }
}
