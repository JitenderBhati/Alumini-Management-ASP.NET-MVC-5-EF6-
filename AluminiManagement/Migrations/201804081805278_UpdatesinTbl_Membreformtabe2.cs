namespace AluminiManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesinTbl_Membreformtabe2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_MemberForm", "imagepath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_MemberForm", "imagepath", c => c.String(maxLength: 200));
        }
    }
}
