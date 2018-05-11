namespace AluminiManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10_51 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_MemberForm", "imagepath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_MemberForm", "imagepath", c => c.String(nullable: false));
        }
    }
}
