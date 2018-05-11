namespace AluminiManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventTabletoDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Events",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 30),
                        dateofevent = c.DateTime(nullable: false),
                        desc = c.String(maxLength: 300),
                        imagepath = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_Events");
        }
    }
}
