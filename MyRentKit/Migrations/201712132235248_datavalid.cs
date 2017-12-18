namespace MyRentKit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datavalid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Equipments", "Title", c => c.String(maxLength: 33));
            AlterColumn("dbo.Equipments", "State", c => c.String(nullable: false, maxLength: 28));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Equipments", "State", c => c.String());
            AlterColumn("dbo.Equipments", "Title", c => c.String());
        }
    }
}
