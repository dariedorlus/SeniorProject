namespace SSCS_LIVE_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Cart_CartID", "dbo.Carts");
            DropForeignKey("dbo.Carts", "User_UserId", "dbo.UserInfoes");
            DropIndex("dbo.Books", new[] { "Cart_CartID" });
            DropIndex("dbo.Carts", new[] { "User_UserId" });
            CreateTable(
                "dbo.CartLines",
                c => new
                    {
                        UniqueID = c.Int(nullable: false, identity: true),
                        CartID = c.String(nullable: false),
                        Book_BookId = c.String(maxLength: 128),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.UniqueID)
                .ForeignKey("dbo.Books", t => t.Book_BookId)
                .ForeignKey("dbo.UserInfoes", t => t.User_UserId)
                .Index(t => t.Book_BookId)
                .Index(t => t.User_UserId);
            
            DropColumn("dbo.Books", "Cart_CartID");
            DropTable("dbo.Carts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.String(nullable: false, maxLength: 128),
                        TotalPrice = c.Double(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.CartID);
            
            AddColumn("dbo.Books", "Cart_CartID", c => c.String(maxLength: 128));
            DropIndex("dbo.CartLines", new[] { "User_UserId" });
            DropIndex("dbo.CartLines", new[] { "Book_BookId" });
            DropForeignKey("dbo.CartLines", "User_UserId", "dbo.UserInfoes");
            DropForeignKey("dbo.CartLines", "Book_BookId", "dbo.Books");
            DropTable("dbo.CartLines");
            CreateIndex("dbo.Carts", "User_UserId");
            CreateIndex("dbo.Books", "Cart_CartID");
            AddForeignKey("dbo.Carts", "User_UserId", "dbo.UserInfoes", "UserId");
            AddForeignKey("dbo.Books", "Cart_CartID", "dbo.Carts", "CartID");
        }
    }
}
