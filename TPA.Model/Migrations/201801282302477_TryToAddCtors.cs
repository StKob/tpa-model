namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryToAddCtors : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MethodMetadatas", "TypeMetadata_Id", "dbo.TypeMetadatas");
            AddColumn("dbo.MethodMetadatas", "TypeMetadata_Id1", c => c.Int());
            CreateIndex("dbo.MethodMetadatas", "TypeMetadata_Id1");
            AddForeignKey("dbo.MethodMetadatas", "TypeMetadata_Id", "dbo.TypeMetadatas", "Id");
            AddForeignKey("dbo.MethodMetadatas", "TypeMetadata_Id1", "dbo.TypeMetadatas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MethodMetadatas", "TypeMetadata_Id1", "dbo.TypeMetadatas");
            DropForeignKey("dbo.MethodMetadatas", "TypeMetadata_Id", "dbo.TypeMetadatas");
            DropIndex("dbo.MethodMetadatas", new[] { "TypeMetadata_Id1" });
            DropColumn("dbo.MethodMetadatas", "TypeMetadata_Id1");
            AddForeignKey("dbo.MethodMetadatas", "TypeMetadata_Id", "dbo.TypeMetadatas", "Id");
        }
    }
}
