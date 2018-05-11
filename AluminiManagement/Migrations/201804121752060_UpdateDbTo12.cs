namespace AluminiManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDbTo12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_MemberForm", "imagepath", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_MemberForm", "imagepath", c => c.String());
        }
    }
}
