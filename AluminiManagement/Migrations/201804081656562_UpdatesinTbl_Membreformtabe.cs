namespace AluminiManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesinTbl_Membreformtabe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_MemberForm", "name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.tbl_MemberForm", "email", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.tbl_MemberForm", "address", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.tbl_MemberForm", "imagepath", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_MemberForm", "imagepath", c => c.String());
            AlterColumn("dbo.tbl_MemberForm", "address", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.tbl_MemberForm", "email", c => c.String(nullable: false));
            AlterColumn("dbo.tbl_MemberForm", "name", c => c.String(nullable: false));
        }
    }
}
