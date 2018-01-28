namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNestedTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TypeMetadatas", "IsNestedInId", c => c.Int());
            CreateIndex("dbo.TypeMetadatas", "IsNestedInId");
            AddForeignKey("dbo.TypeMetadatas", "IsNestedInId", "dbo.TypeMetadatas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TypeMetadatas", "IsNestedInId", "dbo.TypeMetadatas");
            DropIndex("dbo.TypeMetadatas", new[] { "IsNestedInId" });
            DropColumn("dbo.TypeMetadatas", "IsNestedInId");
        }
    }
}
