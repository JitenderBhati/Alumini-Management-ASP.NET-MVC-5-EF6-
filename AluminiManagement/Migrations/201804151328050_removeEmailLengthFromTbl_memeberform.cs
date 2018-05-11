namespace AluminiManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeEmailLengthFromTbl_memeberform : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_MemberForm", "email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_MemberForm", "email", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
