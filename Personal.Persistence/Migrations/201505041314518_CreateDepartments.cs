namespace Personal.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDepartments : DbMigration
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
                .ForeignKey("HR.Location", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("HR.Department", "LocationId", "HR.Location");
            DropIndex("HR.Department", new[] { "LocationId" });
            DropTable("HR.Department");
        }
    }
}
