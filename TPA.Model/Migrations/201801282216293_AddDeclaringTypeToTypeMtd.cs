namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeclaringTypeToTypeMtd : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TypeMetadatas", name: "IsNestedInId", newName: "DeclaringTypeId");
            RenameIndex(table: "dbo.TypeMetadatas", name: "IX_IsNestedInId", newName: "IX_DeclaringTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TypeMetadatas", name: "IX_DeclaringTypeId", newName: "IX_IsNestedInId");
            RenameColumn(table: "dbo.TypeMetadatas", name: "DeclaringTypeId", newName: "IsNestedInId");
        }
    }
}
