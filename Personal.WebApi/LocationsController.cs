using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Http;
using Personal.Entities;
using Personal.Persistence;

namespace Personal.WebApi
{
    public class LocationsController : ApiController
    {
        private readonly HrDbContext context;

        public LocationsController(HrDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Location> Get()
        {
            return context.Locations;
        }

        public Location Get(string id)
        {
            return context.Locations.Find(id);
        }

        public int Post(Location location)
        {
            context.Locations.Add(location);
            return context.SaveChanges();
        }

        public Location Put(string id, Location location)
        {
            var locationDb = context.Locations.Find(id);
            if (locationDb != null)
            {
                locationDb.LocationId = location.LocationId;
                locationDb.City = location.City;
                locationDb.PostalCode = location.PostalCode;
                locationDb.StateProvince = location.StateProvince;
                locationDb.StreetAddress = location.StreetAddress;
            }

            context.SaveChanges();
            return location;
        }

        public void Delete(string id)
        {
            var location = context.Locations.Find(id);
            context.Locations.Remove(location);
            context.SaveChanges();
        }
    }
}