namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMethodsToModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ParameterMetadatas", name: "Type_Id", newName: "ParameterType_Id");
            RenameIndex(table: "dbo.ParameterMetadatas", name: "IX_Type_Id", newName: "IX_ParameterType_Id");
            AddColumn("dbo.MethodMetadatas", "Name", c => c.String());
            AddColumn("dbo.MethodMetadatas", "StaticEnum", c => c.Int());
            AddColumn("dbo.MethodMetadatas", "VirtualEnum", c => c.Int());
            DropColumn("dbo.MethodMetadatas", "SealedEnum");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MethodMetadatas", "SealedEnum", c => c.Int());
            DropColumn("dbo.MethodMetadatas", "VirtualEnum");
            DropColumn("dbo.MethodMetadatas", "StaticEnum");
            DropColumn("dbo.MethodMetadatas", "Name");
            RenameIndex(table: "dbo.ParameterMetadatas", name: "IX_ParameterType_Id", newName: "IX_Type_Id");
            RenameColumn(table: "dbo.ParameterMetadatas", name: "ParameterType_Id", newName: "Type_Id");
        }
    }
}
