namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenericArgumentsDbFixOfFix : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TypeMetadatas", new[] { "IsTemplateInId" });
            AlterColumn("dbo.TypeMetadatas", "IsTemplateInId", c => c.Int());
            CreateIndex("dbo.TypeMetadatas", "IsTemplateInId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TypeMetadatas", new[] { "IsTemplateInId" });
            AlterColumn("dbo.TypeMetadatas", "IsTemplateInId", c => c.Int(nullable: false));
            CreateIndex("dbo.TypeMetadatas", "IsTemplateInId");
        }
    }
}
