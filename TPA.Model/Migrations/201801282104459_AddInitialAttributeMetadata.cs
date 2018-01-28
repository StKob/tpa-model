namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInitialAttributeMetadata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttributeMetadatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AttributeMetadatas");
        }
    }
}
