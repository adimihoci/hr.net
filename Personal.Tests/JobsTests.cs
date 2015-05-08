using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal.Entities;
using Personal.Persistence;
using Shouldly;

namespace Personal.Tests
{
    public class JobsTests
    {
        public void CanAddJob()
        {
            var context = new HrDbContext();

            var deletedJob = context.Jobs.SingleOrDefault(x => x.JobId == "CEO");
            if (deletedJob != null)
            {
                context.Jobs.Remove(deletedJob);
                context.SaveChanges();
            }
            

            var job = new Job
            {
                JobId = "CEO",
                JobTitle = "Chief Executive",
                MinSalary = 1,
                MaxSalary = int.MaxValue
            };
            context.Jobs.Add(job);
            context.SaveChanges();

            var retrievedJob = context.Jobs.Single(j => j.JobId == "CEO");
            retrievedJob.ShouldBe(job);

        }

        public void MaxLengthOnJobTitleThrowsError()
        {
            var context = new HrDbContext();

            var deletedJob = context.Jobs.SingleOrDefault(x => x.JobId == "CE");
            if (deletedJob != null)
            {
                context.Jobs.Remove(deletedJob);
                context.SaveChanges();
            }

            var job = new Job
            {
                JobId = "CE",
                JobTitle = "Chief ExecChief ExecChief ExecChief ExecChief ExecChief ExecChief Exec",
                MinSalary = 1,
                MaxSalary = int.MaxValue
            };
            context.Jobs.Add(job);
            context.SaveChanges();

            Should.Throw<DbEntityValidationException>(() => context.SaveChanges());
        }
    }
}
