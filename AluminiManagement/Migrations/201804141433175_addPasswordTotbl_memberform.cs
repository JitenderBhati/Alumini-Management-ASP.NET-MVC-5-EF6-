namespace AluminiManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPasswordTotbl_memberform : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_MemberForm", "password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_MemberForm", "password");
        }
    }
}
