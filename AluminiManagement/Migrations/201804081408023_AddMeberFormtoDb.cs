namespace AluminiManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMeberFormtoDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_MemberForm",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        uid = c.String(nullable: false),
                        name = c.String(nullable: false),
                        phoneNo = c.String(nullable: false, maxLength: 10),
                        email = c.String(nullable: false),
                        dateofbirth = c.DateTime(nullable: false),
                        address = c.String(nullable: false, maxLength: 200),
                        fathername = c.String(nullable: false),
                        mothername = c.String(nullable: false),
                        collegelastdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_MemberForm");
        }
    }
}
