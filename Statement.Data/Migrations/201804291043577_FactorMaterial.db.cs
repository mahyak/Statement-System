namespace Statement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FactorMaterialdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaterialFactors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FactorId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factors", t => t.FactorId, cascadeDelete: true)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .Index(t => t.FactorId)
                .Index(t => t.MaterialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaterialFactors", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.MaterialFactors", "FactorId", "dbo.Factors");
            DropIndex("dbo.MaterialFactors", new[] { "MaterialId" });
            DropIndex("dbo.MaterialFactors", new[] { "FactorId" });
            DropTable("dbo.MaterialFactors");
        }
    }
}
