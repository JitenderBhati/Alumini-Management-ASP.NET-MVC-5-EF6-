namespace AluminiManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduplodImageinAddMemeberForminDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_MemberForm", "imagepath", c => c.String());
            DropColumn("dbo.tbl_MemberForm", "fathername");
            DropColumn("dbo.tbl_MemberForm", "mothername");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_MemberForm", "mothername", c => c.String(nullable: false));
            AddColumn("dbo.tbl_MemberForm", "fathername", c => c.String(nullable: false));
            DropColumn("dbo.tbl_MemberForm", "imagepath");
        }
    }
}
