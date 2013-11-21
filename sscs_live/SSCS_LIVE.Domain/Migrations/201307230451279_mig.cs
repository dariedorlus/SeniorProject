namespace SSCS_LIVE.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstN = c.String(),
                        LastN = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        School = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        ISBN = c.String(),
                        AuthorFirstN = c.String(),
                        AuthorLastN = c.String(),
                        Condition = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        IsForsale = c.Boolean(nullable: false),
                        IsSold = c.Boolean(nullable: false),
                        Picture = c.String(),
                        User_UserId = c.Int(),
                        Cart_CartID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.UserInfoes", t => t.User_UserId)
                .ForeignKey("dbo.Carts", t => t.Cart_CartID)
                .Index(t => t.User_UserId)
                .Index(t => t.Cart_CartID);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.String(nullable: false, maxLength: 128),
                        TotalPrice = c.Double(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.UserInfoes", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Carts", new[] { "User_UserId" });
            DropIndex("dbo.Books", new[] { "Cart_CartID" });
            DropIndex("dbo.Books", new[] { "User_UserId" });
            DropForeignKey("dbo.Carts", "User_UserId", "dbo.UserInfoes");
            DropForeignKey("dbo.Books", "Cart_CartID", "dbo.Carts");
            DropForeignKey("dbo.Books", "User_UserId", "dbo.UserInfoes");
            DropTable("dbo.Carts");
            DropTable("dbo.Books");
            DropTable("dbo.UserInfoes");
        }
    }
}
