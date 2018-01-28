namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenericArgumentsDbFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TypeMetadatas", "BaseType_Id", "dbo.TypeMetadatas");
            AddColumn("dbo.TypeMetadatas", "IsTemplateInId", c => c.Int(nullable: false));
            CreateIndex("dbo.TypeMetadatas", "IsTemplateInId");
            AddForeignKey("dbo.TypeMetadatas", "IsTemplateInId", "dbo.TypeMetadatas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TypeMetadatas", "IsTemplateInId", "dbo.TypeMetadatas");
            DropIndex("dbo.TypeMetadatas", new[] { "IsTemplateInId" });
            DropColumn("dbo.TypeMetadatas", "IsTemplateInId");
            AddForeignKey("dbo.TypeMetadatas", "BaseType_Id", "dbo.TypeMetadatas", "Id");
        }
    }
}
