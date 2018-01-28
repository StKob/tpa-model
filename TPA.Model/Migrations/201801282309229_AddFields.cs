namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFields : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FieldMetadatas",
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
            DropForeignKey("dbo.FieldMetadatas", "TypeMetadata_Id", "dbo.TypeMetadatas");
            DropIndex("dbo.FieldMetadatas", new[] { "TypeMetadata_Id" });
            DropTable("dbo.FieldMetadatas");
        }
    }
}
