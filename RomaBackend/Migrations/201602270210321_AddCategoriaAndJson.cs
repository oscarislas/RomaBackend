namespace RomaBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriaAndJson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articulo", "Categoria", c => c.Int(nullable: false));
            AddColumn("dbo.Pedido", "Json", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedido", "Json");
            DropColumn("dbo.Articulo", "Categoria");
        }
    }
}
