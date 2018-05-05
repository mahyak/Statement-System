namespace Statement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FactorMaterial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Materials", "FactorId", "dbo.Factors");
            DropIndex("dbo.Materials", new[] { "FactorId" });
            RenameColumn(table: "dbo.Materials", name: "FactorId", newName: "Factor_Id");
            AlterColumn("dbo.Materials", "Factor_Id", c => c.Int());
            CreateIndex("dbo.Materials", "Factor_Id");
            AddForeignKey("dbo.Materials", "Factor_Id", "dbo.Factors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Materials", "Factor_Id", "dbo.Factors");
            DropIndex("dbo.Materials", new[] { "Factor_Id" });
            AlterColumn("dbo.Materials", "Factor_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Materials", name: "Factor_Id", newName: "FactorId");
            CreateIndex("dbo.Materials", "FactorId");
            AddForeignKey("dbo.Materials", "FactorId", "dbo.Factors", "Id", cascadeDelete: true);
        }
    }
}
