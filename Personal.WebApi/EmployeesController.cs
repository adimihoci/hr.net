using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Personal.Persistence;
using Personal.Entities;

namespace Personal.WebApi
{
    public class EmployeesController : ApiController
    {
        private readonly HrDbContext context;

        public EmployeesController(HrDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Employee> Get()
        {
            return context.Employees;
        }

        public Employee Get(string id)
        {
            return context.Employees.Find(id);
        }

        public int Post(string id, Employee employee)
        {
            context.Employees.Add(employee);
            return context.SaveChanges();
        }

        public Employee Put(string id, Employee employee)
        {
            var employeeDb = context.Employees.Find(id);
            if (employeeDb != null)
            {
                employeeDb.Department = employee.Department;
                employeeDb.CommisionPercent = employee.CommisionPercent;
                employeeDb.Email = employee.Email;
                employeeDb.EmployeeId = employee.EmployeeId;
                employeeDb.FirstName = employee.FirstName;
                employeeDb.HireDate = employee.HireDate;
                employeeDb.Job = employee.Job;
                employeeDb.LastName = employee.LastName;
                employeeDb.Manager = employee.Manager;
                employeeDb.PhoneNumber = employee.PhoneNumber;
                employeeDb.Salary = employee.Salary;
            }

            context.SaveChanges();
            return employee;
        }

        public void Delete(string id)
        {
            var employee = context.Employees.Find(id);
            context.Employees.Remove(employee);
            context.SaveChanges();
        }
    }
}