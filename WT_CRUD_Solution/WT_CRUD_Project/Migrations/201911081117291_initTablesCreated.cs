namespace WT_CRUD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initTablesCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectCategoryId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        PublishDate = c.DateTime(nullable: false, storeType: "date"),
                        Desc = c.String(nullable: false, storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectCategories", t => t.ProjectCategoryId, cascadeDelete: true)
                .Index(t => t.ProjectCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ProjectCategoryId", "dbo.ProjectCategories");
            DropIndex("dbo.Projects", new[] { "ProjectCategoryId" });
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectCategories");
        }
    }
}
