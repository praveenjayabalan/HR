namespace HR.Migrations.HrMigrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                {
                    DepartmentID = c.Long(nullable: false, identity: true),
                    Department_Name = c.String(nullable: false, maxLength: 500),
                    Department_Code = c.String(nullable: false, maxLength: 500),
                    Is_Actv = c.Boolean(),
                    Is_Del = c.Boolean(),
                    Crtd_by = c.Long(),
                    Crtd_ts = c.DateTime(),
                    Mod_by = c.Long(),
                    Mod_ts = c.DateTime(),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    OrganizationID = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.Organization", t => t.OrganizationID, cascadeDelete: true)
                .Index(t => t.OrganizationID);

            CreateTable(
                "dbo.Designation",
                c => new
                {
                    DesignationID = c.Long(nullable: false, identity: true),
                    Designation_Name = c.String(nullable: false, maxLength: 500),
                    Designation_code = c.String(nullable: false, maxLength: 500),
                    Is_Actv = c.Boolean(),
                    Is_Del = c.Boolean(),
                    Crtd_by = c.Long(),
                    Crtd_ts = c.DateTime(),
                    Mod_by = c.Long(),
                    Mod_ts = c.DateTime(),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    DepartmentID = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.DesignationID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);

            CreateTable(
                "dbo.Employee",
                c => new
                {
                    EmployeeID = c.Long(nullable: false, identity: true),
                    Employee_Name = c.String(nullable: false, maxLength: 500),
                    Employee_Code = c.String(nullable: false, maxLength: 500),
                    Email = c.String(nullable: false, maxLength: 500),
                    Date_Of_Birth = c.DateTime(nullable: false),
                    Address = c.String(maxLength: 500),
                    Contact_No = c.String(maxLength: 50),
                    Emergency_Contact_No = c.String(maxLength: 50),
                    Qualifications = c.String(maxLength: 250),
                    Is_Actv = c.Boolean(),
                    Is_Del = c.Boolean(),
                    Crtd_by = c.Long(),
                    Crtd_ts = c.DateTime(),
                    Mod_by = c.Long(),
                    Mod_ts = c.DateTime(),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    EmployeeTypeId = c.Long(nullable: false),
                    DesignationId = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Designation", t => t.DesignationId, cascadeDelete: true)
                .ForeignKey("dbo.EmployeeType", t => t.EmployeeTypeId, cascadeDelete: true)
                .Index(t => t.EmployeeTypeId)
                .Index(t => t.DesignationId);

            CreateTable(
                "dbo.EmployeeType",
                c => new
                {
                    EmployeeTypeId = c.Long(nullable: false, identity: true),
                    EmployeeTyp = c.String(maxLength: 50),
                    Desc = c.String(maxLength: 500),
                    Is_Actv = c.Boolean(),
                    Is_Del = c.Boolean(),
                    Crtd_by = c.Long(),
                    Crtd_ts = c.DateTime(),
                    Mod_by = c.Long(),
                    Mod_ts = c.DateTime(),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.EmployeeTypeId);

            CreateTable(
                "dbo.Organization",
                c => new
                {
                    OrganizationID = c.Long(nullable: false, identity: true),
                    Organization_Name = c.String(nullable: false, maxLength: 500),
                    Organization_code = c.String(nullable: false, maxLength: 500),
                    Is_Actv = c.Boolean(),
                    Is_Del = c.Boolean(),
                    Crtd_by = c.Long(),
                    Crtd_ts = c.DateTime(),
                    Mod_by = c.Long(),
                    Mod_ts = c.DateTime(),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.OrganizationID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Department", "OrganizationID", "dbo.Organization");
            DropForeignKey("dbo.Employee", "EmployeeTypeId", "dbo.EmployeeType");
            DropForeignKey("dbo.Employee", "DesignationId", "dbo.Designation");
            DropForeignKey("dbo.Designation", "DepartmentID", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "DesignationId" });
            DropIndex("dbo.Employee", new[] { "EmployeeTypeId" });
            DropIndex("dbo.Designation", new[] { "DepartmentID" });
            DropIndex("dbo.Department", new[] { "OrganizationID" });
            DropTable("dbo.Organization");
            DropTable("dbo.EmployeeType");
            DropTable("dbo.Employee");
            DropTable("dbo.Designation");
            DropTable("dbo.Department");
        }
    }
}
