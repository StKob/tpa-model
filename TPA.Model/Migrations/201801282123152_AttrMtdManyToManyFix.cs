namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttrMtdManyToManyFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AttributeMetadatas", "TypeMetadata_Id", "dbo.TypeMetadatas");
            DropIndex("dbo.AttributeMetadatas", new[] { "TypeMetadata_Id" });
            CreateTable(
                "dbo.TypesAttributes",
                c => new
                    {
                        TypeId = c.Int(nullable: false),
                        AttributeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TypeId, t.AttributeId })
                .ForeignKey("dbo.TypeMetadatas", t => t.TypeId, cascadeDelete: true)
                .ForeignKey("dbo.AttributeMetadatas", t => t.AttributeId, cascadeDelete: true)
                .Index(t => t.TypeId)
                .Index(t => t.AttributeId);
            
            DropColumn("dbo.AttributeMetadatas", "TypeMetadata_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AttributeMetadatas", "TypeMetadata_Id", c => c.Int());
            DropForeignKey("dbo.TypesAttributes", "AttributeId", "dbo.AttributeMetadatas");
            DropForeignKey("dbo.TypesAttributes", "TypeId", "dbo.TypeMetadatas");
            DropIndex("dbo.TypesAttributes", new[] { "AttributeId" });
            DropIndex("dbo.TypesAttributes", new[] { "TypeId" });
            DropTable("dbo.TypesAttributes");
            CreateIndex("dbo.AttributeMetadatas", "TypeMetadata_Id");
            AddForeignKey("dbo.AttributeMetadatas", "TypeMetadata_Id", "dbo.TypeMetadatas", "Id");
        }
    }
}
