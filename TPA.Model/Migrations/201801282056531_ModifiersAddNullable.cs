namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiersAddNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TypeMetadatas", "AccessLevel", c => c.Int());
            AlterColumn("dbo.TypeMetadatas", "SealedEnum", c => c.Int());
            AlterColumn("dbo.TypeMetadatas", "AbstractEnum", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TypeMetadatas", "AbstractEnum", c => c.Int(nullable: false));
            AlterColumn("dbo.TypeMetadatas", "SealedEnum", c => c.Int(nullable: false));
            AlterColumn("dbo.TypeMetadatas", "AccessLevel", c => c.Int(nullable: false));
        }
    }
}
