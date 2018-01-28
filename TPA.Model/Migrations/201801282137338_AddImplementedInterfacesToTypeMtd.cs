namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImplementedInterfacesToTypeMtd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypesInterfaces",
                c => new
                    {
                        ImplementorId = c.Int(nullable: false),
                        InterfaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ImplementorId, t.InterfaceId })
                .ForeignKey("dbo.TypeMetadatas", t => t.ImplementorId)
                .ForeignKey("dbo.TypeMetadatas", t => t.InterfaceId)
                .Index(t => t.ImplementorId)
                .Index(t => t.InterfaceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TypesInterfaces", "InterfaceId", "dbo.TypeMetadatas");
            DropForeignKey("dbo.TypesInterfaces", "ImplementorId", "dbo.TypeMetadatas");
            DropIndex("dbo.TypesInterfaces", new[] { "InterfaceId" });
            DropIndex("dbo.TypesInterfaces", new[] { "ImplementorId" });
            DropTable("dbo.TypesInterfaces");
        }
    }
}
