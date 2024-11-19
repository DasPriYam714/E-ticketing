namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDb2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Managers");
            AlterColumn("dbo.Managers", "Manager_Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Managers", "Manager_Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Managers");
            AlterColumn("dbo.Managers", "Manager_Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Managers", "Manager_Id");
        }
    }
}
