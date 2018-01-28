namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImplementAttributeMetadata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AttributeMetadatas", "Name", c => c.String());
            AddColumn("dbo.AttributeMetadatas", "AttributeType_Id", c => c.Int());
            CreateIndex("dbo.AttributeMetadatas", "AttributeType_Id");
            AddForeignKey("dbo.AttributeMetadatas", "AttributeType_Id", "dbo.TypeMetadatas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AttributeMetadatas", "AttributeType_Id", "dbo.TypeMetadatas");
            DropIndex("dbo.AttributeMetadatas", new[] { "AttributeType_Id" });
            DropColumn("dbo.AttributeMetadatas", "AttributeType_Id");
            DropColumn("dbo.AttributeMetadatas", "Name");
        }
    }
}
