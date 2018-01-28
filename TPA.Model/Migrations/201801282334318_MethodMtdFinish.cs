namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MethodMtdFinish : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Methods_Attributes",
                c => new
                    {
                        MethodId = c.Int(nullable: false),
                        AttributeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MethodId, t.AttributeId })
                .ForeignKey("dbo.MethodMetadatas", t => t.MethodId, cascadeDelete: true)
                .ForeignKey("dbo.AttributeMetadatas", t => t.AttributeId, cascadeDelete: true)
                .Index(t => t.MethodId)
                .Index(t => t.AttributeId);
            
            AddColumn("dbo.MethodMetadatas", "IsExtensionMethod", c => c.Boolean(nullable: false));
            AddColumn("dbo.MethodMetadatas", "ReturnType_Id", c => c.Int());
            AddColumn("dbo.ParameterMetadatas", "MethodMetadata_Id", c => c.Int());
            CreateIndex("dbo.MethodMetadatas", "ReturnType_Id");
            CreateIndex("dbo.ParameterMetadatas", "MethodMetadata_Id");
            AddForeignKey("dbo.ParameterMetadatas", "MethodMetadata_Id", "dbo.MethodMetadatas", "Id");
            AddForeignKey("dbo.MethodMetadatas", "ReturnType_Id", "dbo.TypeMetadatas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MethodMetadatas", "ReturnType_Id", "dbo.TypeMetadatas");
            DropForeignKey("dbo.ParameterMetadatas", "MethodMetadata_Id", "dbo.MethodMetadatas");
            DropForeignKey("dbo.Methods_Attributes", "AttributeId", "dbo.AttributeMetadatas");
            DropForeignKey("dbo.Methods_Attributes", "MethodId", "dbo.MethodMetadatas");
            DropIndex("dbo.Methods_Attributes", new[] { "AttributeId" });
            DropIndex("dbo.Methods_Attributes", new[] { "MethodId" });
            DropIndex("dbo.ParameterMetadatas", new[] { "MethodMetadata_Id" });
            DropIndex("dbo.MethodMetadatas", new[] { "ReturnType_Id" });
            DropColumn("dbo.ParameterMetadatas", "MethodMetadata_Id");
            DropColumn("dbo.MethodMetadatas", "ReturnType_Id");
            DropColumn("dbo.MethodMetadatas", "IsExtensionMethod");
            DropTable("dbo.Methods_Attributes");
        }
    }
}
