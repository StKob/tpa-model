namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypeKind : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TypeMetadatas", "KindOfType", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TypeMetadatas", "KindOfType");
        }
    }
}
