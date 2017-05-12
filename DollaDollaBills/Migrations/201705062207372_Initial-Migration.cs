namespace DollaDollaBills.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Location = c.String(),
                        User = c.String(),
                        Desription = c.String(),
                        TotalBillsModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TotalBillsModels", t => t.TotalBillsModel_Id)
                .Index(t => t.TotalBillsModel_Id);
            
            CreateTable(
                "dbo.TotalBillsModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receipts", "TotalBillsModel_Id", "dbo.TotalBillsModels");
            DropIndex("dbo.Receipts", new[] { "TotalBillsModel_Id" });
            DropTable("dbo.TotalBillsModels");
            DropTable("dbo.Receipts");
        }
    }
}
