namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssemblyMetadatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NamespaceMetadatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AssemblyMetadata_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssemblyMetadatas", t => t.AssemblyMetadata_Id)
                .Index(t => t.AssemblyMetadata_Id);
            
            CreateTable(
                "dbo.TypeMetadatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NamespaceMetadata_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NamespaceMetadatas", t => t.NamespaceMetadata_Id)
                .Index(t => t.NamespaceMetadata_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NamespaceMetadatas", "AssemblyMetadata_Id", "dbo.AssemblyMetadatas");
            DropForeignKey("dbo.TypeMetadatas", "NamespaceMetadata_Id", "dbo.NamespaceMetadatas");
            DropIndex("dbo.TypeMetadatas", new[] { "NamespaceMetadata_Id" });
            DropIndex("dbo.NamespaceMetadatas", new[] { "AssemblyMetadata_Id" });
            DropTable("dbo.TypeMetadatas");
            DropTable("dbo.NamespaceMetadatas");
            DropTable("dbo.AssemblyMetadatas");
        }
    }
}
