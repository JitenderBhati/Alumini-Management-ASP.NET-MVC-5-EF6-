namespace AluminiManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addgallerytabletodb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_gallery",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        imagepath = c.String(maxLength: 200),
                        title = c.String(nullable: false, maxLength: 50),
                        desc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_gallery");
        }
    }
}
