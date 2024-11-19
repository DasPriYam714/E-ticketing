namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDb1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Trans_ID = c.Int(nullable: false, identity: true),
                        Trans_name = c.String(nullable: false, maxLength: 25),
                        trans_date = c.DateTime(nullable: false),
                        Ticket_ID = c.Int(nullable: false),
                        Res_ID = c.Int(nullable: false),
                        User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Trans_ID)
                .ForeignKey("dbo.Bookings", t => t.Res_ID, cascadeDelete: false)
                .ForeignKey("dbo.Tickets", t => t.Ticket_ID, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.User_ID, cascadeDelete: false)
                .Index(t => t.Ticket_ID)
                .Index(t => t.Res_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Booking_ID = c.Int(nullable: false, identity: true),
                        User_ID = c.Int(nullable: false),
                        Ticket_ID = c.Int(nullable: false),
                        Booking_Date = c.DateTime(nullable: false),
                        Payment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Booking_ID)
                .ForeignKey("dbo.Tickets", t => t.Ticket_ID, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.User_ID, cascadeDelete: false)
                .Index(t => t.User_ID)
                .Index(t => t.Ticket_ID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        T_Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                        Purchase_Date = c.DateTime(nullable: false),
                        Price = c.Single(nullable: false),
                        Description = c.String(),
                        Posted_by = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.T_Id)
                .ForeignKey("dbo.Users", t => t.Posted_by, cascadeDelete: false)
                .Index(t => t.Posted_by);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        U_ID = c.Int(nullable: false, identity: true),
                        U_Name = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 20),
                        Name = c.String(nullable: false, maxLength: 30),
                        Type = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.U_ID);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Report_Id = c.Int(nullable: false, identity: true),
                        Report_Date = c.DateTime(nullable: false),
                        Income = c.String(nullable: false),
                        Expense = c.String(nullable: false),
                        T_ID = c.Int(nullable: false),
                        B_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Report_Id)
                .ForeignKey("dbo.Bookings", t => t.B_ID, cascadeDelete: false)
                .ForeignKey("dbo.Transactions", t => t.T_ID, cascadeDelete: false)
                .Index(t => t.T_ID)
                .Index(t => t.B_ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Comment_Id = c.Int(nullable: false, identity: true),
                        Comment_Text = c.String(nullable: false),
                        Comment_Time = c.DateTime(nullable: false),
                        Comment_By = c.Int(nullable: false),
                        Post_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Comment_Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.Comment_By, cascadeDelete: false)
                .Index(t => t.Comment_By)
                .Index(t => t.Post_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Post_Id = c.Int(nullable: false, identity: true),
                        Post_Title = c.String(nullable: false),
                        Post_Description = c.String(nullable: false),
                        Posted_By = c.Int(nullable: false),
                        Post_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Post_Id)
                .ForeignKey("dbo.Users", t => t.Posted_By, cascadeDelete: false)
                .Index(t => t.Posted_By);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Manager_Id = c.String(nullable: false, maxLength: 128),
                        Manager_Name = c.String(nullable: false, maxLength: 50),
                        Movie = c.String(nullable: false, maxLength: 50),
                        Movie_Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Manager_Id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                        UserId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Admins", "T_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Admins", "T_ID");
            AddForeignKey("dbo.Admins", "T_ID", "dbo.Transactions", "Trans_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Comment_By", "dbo.Users");
            DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Posts", "Posted_By", "dbo.Users");
            DropForeignKey("dbo.Admins", "T_ID", "dbo.Transactions");
            DropForeignKey("dbo.Transactions", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Transactions", "Ticket_ID", "dbo.Tickets");
            DropForeignKey("dbo.Reports", "T_ID", "dbo.Transactions");
            DropForeignKey("dbo.Reports", "B_ID", "dbo.Bookings");
            DropForeignKey("dbo.Transactions", "Res_ID", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Bookings", "Ticket_ID", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "Posted_by", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "Posted_By" });
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            DropIndex("dbo.Comments", new[] { "Comment_By" });
            DropIndex("dbo.Reports", new[] { "B_ID" });
            DropIndex("dbo.Reports", new[] { "T_ID" });
            DropIndex("dbo.Tickets", new[] { "Posted_by" });
            DropIndex("dbo.Bookings", new[] { "Ticket_ID" });
            DropIndex("dbo.Bookings", new[] { "User_ID" });
            DropIndex("dbo.Transactions", new[] { "User_ID" });
            DropIndex("dbo.Transactions", new[] { "Res_ID" });
            DropIndex("dbo.Transactions", new[] { "Ticket_ID" });
            DropIndex("dbo.Admins", new[] { "T_ID" });
            DropColumn("dbo.Admins", "T_ID");
            DropTable("dbo.Tokens");
            DropTable("dbo.Managers");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.Reports");
            DropTable("dbo.Users");
            DropTable("dbo.Tickets");
            DropTable("dbo.Bookings");
            DropTable("dbo.Transactions");
        }
    }
}
