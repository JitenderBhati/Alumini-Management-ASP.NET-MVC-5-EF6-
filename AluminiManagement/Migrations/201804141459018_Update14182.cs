namespace AluminiManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update14182 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tbl_MemberForm", "imagepath");
           
            
        }
        
        public override void Down()
        {
           
        }
    }
}
