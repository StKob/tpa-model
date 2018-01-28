namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAndImplementParameterMetadata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParameterMetadatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeMetadatas", t => t.Type_Id)
                .Index(t => t.Type_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParameterMetadatas", "Type_Id", "dbo.TypeMetadatas");
            DropIndex("dbo.ParameterMetadatas", new[] { "Type_Id" });
            DropTable("dbo.ParameterMetadatas");
        }
    }
}
