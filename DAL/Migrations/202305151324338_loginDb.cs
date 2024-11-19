namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loginDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tokens", "User_U_ID", c => c.Int());
            AlterColumn("dbo.Tokens", "DeletedAt", c => c.DateTime());
            CreateIndex("dbo.Tokens", "User_U_ID");
            AddForeignKey("dbo.Tokens", "User_U_ID", "dbo.Users", "U_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "User_U_ID", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "User_U_ID" });
            AlterColumn("dbo.Tokens", "DeletedAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tokens", "User_U_ID");
        }
    }
}
