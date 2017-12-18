namespace MyRentKit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class State : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipments", "State", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Equipments", "State");
        }
    }
}
