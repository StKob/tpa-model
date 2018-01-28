namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBooleansToTypeMtd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TypeMetadatas", "IsBuiltIn", c => c.Boolean(nullable: false));
            AddColumn("dbo.TypeMetadatas", "IsGeneric", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TypeMetadatas", "IsGeneric");
            DropColumn("dbo.TypeMetadatas", "IsBuiltIn");
        }
    }
}
