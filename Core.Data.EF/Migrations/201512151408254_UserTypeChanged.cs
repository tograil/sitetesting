namespace Core.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTypeChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserName", c => c.String());
            AddColumn("dbo.UserRoles", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserRoles", "Name");
            DropColumn("dbo.Users", "UserName");
        }
    }
}
