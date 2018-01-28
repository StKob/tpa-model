namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInitialPropertyMetadata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PropertyMetadatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TypeMetadata_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeMetadatas", t => t.TypeMetadata_Id)
                .Index(t => t.TypeMetadata_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertyMetadatas", "TypeMetadata_Id", "dbo.TypeMetadatas");
            DropIndex("dbo.PropertyMetadatas", new[] { "TypeMetadata_Id" });
            DropTable("dbo.PropertyMetadatas");
        }
    }
}
