namespace WT_CRUD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryNameAttributeChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProjectCategories", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjectCategories", "Name", c => c.String(nullable: false));
        }
    }
}
