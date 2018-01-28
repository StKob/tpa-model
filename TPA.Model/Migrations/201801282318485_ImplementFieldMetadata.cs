namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImplementFieldMetadata : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TypesAttributes", newName: "Types_UsedAttributes");
            RenameTable(name: "dbo.TypesInterfaces", newName: "Types_ImplementedInterfaces");
            RenameColumn(table: "dbo.FieldMetadatas", name: "TypeMetadata_Id", newName: "Type_Id");
            RenameIndex(table: "dbo.FieldMetadatas", name: "IX_TypeMetadata_Id", newName: "IX_Type_Id");
            AddColumn("dbo.FieldMetadatas", "Name", c => c.String());
            AddColumn("dbo.FieldMetadatas", "StaticModifier", c => c.Int(nullable: false));
            AddColumn("dbo.FieldMetadatas", "AccessModifier", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FieldMetadatas", "AccessModifier");
            DropColumn("dbo.FieldMetadatas", "StaticModifier");
            DropColumn("dbo.FieldMetadatas", "Name");
            RenameIndex(table: "dbo.FieldMetadatas", name: "IX_Type_Id", newName: "IX_TypeMetadata_Id");
            RenameColumn(table: "dbo.FieldMetadatas", name: "Type_Id", newName: "TypeMetadata_Id");
            RenameTable(name: "dbo.Types_ImplementedInterfaces", newName: "TypesInterfaces");
            RenameTable(name: "dbo.Types_UsedAttributes", newName: "TypesAttributes");
        }
    }
}
