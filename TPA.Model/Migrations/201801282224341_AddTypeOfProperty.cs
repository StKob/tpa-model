namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypeOfProperty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PropertyMetadatas", "TypeMetadata_Id", "dbo.TypeMetadatas");
            DropIndex("dbo.PropertyMetadatas", new[] { "TypeMetadata_Id" });
            RenameColumn(table: "dbo.PropertyMetadatas", name: "TypeMetadata_Id", newName: "TypeId");
            AlterColumn("dbo.PropertyMetadatas", "TypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.PropertyMetadatas", "TypeId");
            AddForeignKey("dbo.PropertyMetadatas", "TypeId", "dbo.TypeMetadatas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertyMetadatas", "TypeId", "dbo.TypeMetadatas");
            DropIndex("dbo.PropertyMetadatas", new[] { "TypeId" });
            AlterColumn("dbo.PropertyMetadatas", "TypeId", c => c.Int());
            RenameColumn(table: "dbo.PropertyMetadatas", name: "TypeId", newName: "TypeMetadata_Id");
            CreateIndex("dbo.PropertyMetadatas", "TypeMetadata_Id");
            AddForeignKey("dbo.PropertyMetadatas", "TypeMetadata_Id", "dbo.TypeMetadatas", "Id");
        }
    }
}
