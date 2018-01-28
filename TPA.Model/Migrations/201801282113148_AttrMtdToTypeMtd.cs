namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttrMtdToTypeMtd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AttributeMetadatas", "TypeMetadata_Id", c => c.Int());
            CreateIndex("dbo.AttributeMetadatas", "TypeMetadata_Id");
            AddForeignKey("dbo.AttributeMetadatas", "TypeMetadata_Id", "dbo.TypeMetadatas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AttributeMetadatas", "TypeMetadata_Id", "dbo.TypeMetadatas");
            DropIndex("dbo.AttributeMetadatas", new[] { "TypeMetadata_Id" });
            DropColumn("dbo.AttributeMetadatas", "TypeMetadata_Id");
        }
    }
}
