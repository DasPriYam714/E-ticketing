namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accountants",
                c => new
                    {
                        A_Id = c.Int(nullable: false, identity: true),
                        A_Name = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 20),
                        Name = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.A_Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        M_Id = c.Int(nullable: false, identity: true),
                        M_Name = c.String(nullable: false),
                        Time = c.Single(nullable: false),
                        Showtime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.M_Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        R_Id = c.Int(nullable: false, identity: true),
                        ratings = c.Single(nullable: false),
                        U_ID = c.Int(nullable: false),
                        M_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.R_Id)
                .ForeignKey("dbo.Movies", t => t.M_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.U_ID, cascadeDelete: true)
                .Index(t => t.U_ID)
                .Index(t => t.M_Id);
            
            CreateTable(
                "dbo.UpcomingMovies",
                c => new
                    {
                        UM_Id = c.Int(nullable: false, identity: true),
                        UM_Name = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UM_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "U_ID", "dbo.Users");
            DropForeignKey("dbo.Ratings", "M_Id", "dbo.Movies");
            DropIndex("dbo.Ratings", new[] { "M_Id" });
            DropIndex("dbo.Ratings", new[] { "U_ID" });
            DropTable("dbo.UpcomingMovies");
            DropTable("dbo.Ratings");
            DropTable("dbo.Movies");
            DropTable("dbo.Accountants");
        }
    }
}
