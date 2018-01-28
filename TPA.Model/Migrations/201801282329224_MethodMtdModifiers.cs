namespace TPA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MethodMtdModifiers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MethodMetadatas", "AccessLevel", c => c.Int());
            AddColumn("dbo.MethodMetadatas", "SealedEnum", c => c.Int());
            AddColumn("dbo.MethodMetadatas", "AbstractEnum", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MethodMetadatas", "AbstractEnum");
            DropColumn("dbo.MethodMetadatas", "SealedEnum");
            DropColumn("dbo.MethodMetadatas", "AccessLevel");
        }
    }
}
