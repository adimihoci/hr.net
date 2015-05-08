using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Personal.Entities;
using Personal.Persistence;

namespace Personal.WebApi
{
    public class DepartmentsController : ApiController
    {
        private readonly HrDbContext context;

        public DepartmentsController(HrDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Department> Get()
        {
            return context.Departments;
        }

        public Department Get(string id)
        {
            return context.Departments.Find(id);
        }

        public int Post(Department department)
        {
            context.Departments.Add(department);
            return context.SaveChanges();
        }

        public Department Put(string id, Department department)
        {
            var departmentDb = context.Departments.Find(id);
            if (departmentDb != null)
            {
                departmentDb.Location = department.Location;
                departmentDb.DepartmentId = department.DepartmentId;
                departmentDb.DepartmentName = department.DepartmentName;
                departmentDb.LocationId = department.LocationId;
            }

            context.SaveChanges();
            return department;
        }

        public void Delete(string id)
        {
            var department = context.Departments.Find(id);
            context.Departments.Remove(department);
            context.SaveChanges();
        }
    }
}