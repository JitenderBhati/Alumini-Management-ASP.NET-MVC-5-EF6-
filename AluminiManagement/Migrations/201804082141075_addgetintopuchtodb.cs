namespace AluminiManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addgetintopuchtodb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_getintouch",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        mobileNo = c.String(nullable: false, maxLength: 10),
                        email = c.String(nullable: false, maxLength: 20),
                        message = c.String(nullable: false, maxLength: 200),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_getintouch");
        }
    }
}
