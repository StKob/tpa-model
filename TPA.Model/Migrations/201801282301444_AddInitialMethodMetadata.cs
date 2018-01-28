namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInitialMethodMetadata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MethodMetadatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeMetadata_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeMetadatas", t => t.TypeMetadata_Id)
                .Index(t => t.TypeMetadata_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MethodMetadatas", "TypeMetadata_Id", "dbo.TypeMetadatas");
            DropIndex("dbo.MethodMetadatas", new[] { "TypeMetadata_Id" });
            DropTable("dbo.MethodMetadatas");
        }
    }
}
