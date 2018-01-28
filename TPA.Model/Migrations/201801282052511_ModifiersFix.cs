namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiersFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TypeMetadatas", "SealedEnum", c => c.Int(nullable: false));
            AddColumn("dbo.TypeMetadatas", "AbstractEnum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TypeMetadatas", "AbstractEnum");
            DropColumn("dbo.TypeMetadatas", "SealedEnum");
        }
    }
}
