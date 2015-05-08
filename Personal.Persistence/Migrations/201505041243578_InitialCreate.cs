namespace Personal.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("HR.Location");
            DropTable("HR.Job");
        }
    }
}
