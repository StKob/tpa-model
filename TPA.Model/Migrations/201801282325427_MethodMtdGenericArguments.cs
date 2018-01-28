namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MethodMtdGenericArguments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TypeMetadatas", "MethodMetadata_Id", c => c.Int());
            CreateIndex("dbo.TypeMetadatas", "MethodMetadata_Id");
            AddForeignKey("dbo.TypeMetadatas", "MethodMetadata_Id", "dbo.MethodMetadatas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TypeMetadatas", "MethodMetadata_Id", "dbo.MethodMetadatas");
            DropIndex("dbo.TypeMetadatas", new[] { "MethodMetadata_Id" });
            DropColumn("dbo.TypeMetadatas", "MethodMetadata_Id");
        }
    }
}
