namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NamespaceNameInTypeMetadata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TypeMetadatas", "NamespaceName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TypeMetadatas", "NamespaceName");
        }
    }
}
