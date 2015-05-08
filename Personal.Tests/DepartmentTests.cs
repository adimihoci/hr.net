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
    class DepartmentTests
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

                var department = new Department()
                {
                    DepartmentName = "D1",
                    Location = location
                };

                context.Departments.Add(department);
                context.SaveChanges();

                var retrievedDep = context.Departments.Single((l => l.DepartmentId == department.DepartmentId));
                retrievedDep.ShouldBe(department);
            }
            ;
        }

        public void IncludeExample()
        {
            
        }
            
    }
}

