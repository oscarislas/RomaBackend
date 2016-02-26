namespace RomaBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexToClave : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Cliente", "Clave", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cliente", new[] { "Clave" });
        }
    }
}
