namespace Core.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ignoreidentityfields : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserName", c => c.String());
        }
    }
}
