namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.WorkNotes",
                c => new
                    {
                        WorkNoteId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        StartTime = c.Int(nullable: false),
                        EndTime = c.Int(nullable: false),
                        Date = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.WorkNoteId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkNotes", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.WorkNotes", new[] { "EmployeeId" });
            DropTable("dbo.WorkNotes");
            DropTable("dbo.Employees");
        }
    }
}
