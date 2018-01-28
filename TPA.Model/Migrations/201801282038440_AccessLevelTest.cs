namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccessLevelTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TypeMetadatas", "AccessLevel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TypeMetadatas", "AccessLevel");
        }
    }
}
