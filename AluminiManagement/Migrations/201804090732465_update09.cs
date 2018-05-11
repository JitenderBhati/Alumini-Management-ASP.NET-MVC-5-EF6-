namespace AluminiManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update09 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.AboutUs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AboutUs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        aboutus = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
    }
}
