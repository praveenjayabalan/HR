namespace HR.Migrations.HrMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HolidayAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Holidays",
                c => new
                    {
                        Holidayid = c.Int(nullable: false, identity: true),
                        HolidayName = c.String(maxLength: 50),
                        Desc = c.String(maxLength: 500),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        OrganizationID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Holidayid)
                .ForeignKey("dbo.Organization", t => t.OrganizationID, cascadeDelete: true)
                .Index(t => t.OrganizationID);
            
          
        }
        
        public override void Down()
        {
            
            DropForeignKey("dbo.Holidays", "OrganizationID", "dbo.Organization");
            DropIndex("dbo.Holidays", new[] { "OrganizationID" });            
            DropTable("dbo.Holidays");
        }
    }
}
