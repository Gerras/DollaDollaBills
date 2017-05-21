namespace DollaDollaBills.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSpendingModelV2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpendingModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MonthlySpendingLimit = c.Int(nullable: false),
                        MonthlyIncome = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SpendingModels");
        }
    }
}
