namespace DollaDollaBills.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSpendingModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receipts", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Receipts", "DateAdded");
        }
    }
}
