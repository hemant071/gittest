namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNumberAvailableToRental : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "NumberAvailable", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "NumberAvailable");
        }
    }
}
