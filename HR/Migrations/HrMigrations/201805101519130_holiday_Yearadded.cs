namespace HR.Migrations.HrMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class holiday_Yearadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Holidays", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Holidays", "Year");
        }
    }
}
