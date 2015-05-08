namespace Personal.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCascadeDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("HR.Department", "LocationId", "HR.Location");
            AddForeignKey("HR.Department", "LocationId", "HR.Location", "LocationId");
        }
        
        public override void Down()
        {
            DropForeignKey("HR.Department", "LocationId", "HR.Location");
            AddForeignKey("HR.Department", "LocationId", "HR.Location", "LocationId", cascadeDelete: true);
        }
    }
}
