namespace Personal.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "HR.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("HR.Location", t => t.LocationId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "HR.Location",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        StreetAddress = c.String(),
                        PostalCode = c.String(),
                        City = c.String(maxLength: 50),
                        StateProvince = c.String(),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "HR.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        Email = c.String(maxLength: 20),
                        PhoneNumber = c.String(maxLength: 15),
                        HireDate = c.DateTime(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CommisionPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Department_DepartmentId = c.Int(),
                        Job_JobId = c.String(maxLength: 128),
                        Manager_EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("HR.Department", t => t.Department_DepartmentId)
                .ForeignKey("HR.Job", t => t.Job_JobId)
                .ForeignKey("HR.Employee", t => t.Manager_EmployeeId)
                .Index(t => t.Department_DepartmentId)
                .Index(t => t.Job_JobId)
                .Index(t => t.Manager_EmployeeId);
            
            CreateTable(
                "HR.Job",
                c => new
                    {
                        JobId = c.String(nullable: false, maxLength: 128),
                        JobTitle = c.String(maxLength: 25),
                        MinSalary = c.Int(nullable: false),
                        MaxSalary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("HR.Employee", "Manager_EmployeeId", "HR.Employee");
            DropForeignKey("HR.Employee", "Job_JobId", "HR.Job");
            DropForeignKey("HR.Employee", "Department_DepartmentId", "HR.Department");
            DropForeignKey("HR.Department", "LocationId", "HR.Location");
            DropIndex("HR.Employee", new[] { "Manager_EmployeeId" });
            DropIndex("HR.Employee", new[] { "Job_JobId" });
            DropIndex("HR.Employee", new[] { "Department_DepartmentId" });
            DropIndex("HR.Department", new[] { "LocationId" });
            DropTable("HR.Job");
            DropTable("HR.Employee");
            DropTable("HR.Location");
            DropTable("HR.Department");
        }
    }
}
