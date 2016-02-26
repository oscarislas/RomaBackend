namespace RomaBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticuloPedido",
                c => new
                    {
                        PedidoID = c.Guid(nullable: false),
                        ArticuloID = c.Guid(nullable: false),
                        Cantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Indicaciones = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => new { t.PedidoID, t.ArticuloID })
                .ForeignKey("dbo.Articulo", t => t.ArticuloID, cascadeDelete: true)
                .ForeignKey("dbo.Pedido", t => t.PedidoID, cascadeDelete: true)
                .Index(t => t.PedidoID)
                .Index(t => t.ArticuloID);
            
            CreateTable(
                "dbo.Articulo",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Code = c.String(maxLength: 10),
                        Descripcion = c.String(maxLength: 50),
                        Marca = c.String(maxLength: 30),
                        Unidades = c.String(maxLength: 5),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Existencia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ClienteID = c.Guid(nullable: false),
                        FechaPedido = c.DateTime(nullable: false),
                        FechaEntrega = c.DateTime(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cliente", t => t.ClienteID, cascadeDelete: true)
                .Index(t => t.ClienteID);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Clave = c.String(maxLength: 50),
                        Nombre = c.String(maxLength: 100),
                        Calle = c.String(maxLength: 200),
                        Colonia = c.String(maxLength: 100),
                        Ciudad = c.String(maxLength: 50),
                        Correo = c.String(maxLength: 50),
                        Indicaciones = c.String(maxLength: 500),
                        RFC = c.String(maxLength: 20),
                        NombreFactura = c.String(maxLength: 100),
                        CalleFactura = c.String(maxLength: 200),
                        ColoniaFactura = c.String(maxLength: 100),
                        CiudadFactura = c.String(maxLength: 50),
                        CorreoFactura = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticuloPedido", "PedidoID", "dbo.Pedido");
            DropForeignKey("dbo.Pedido", "ClienteID", "dbo.Cliente");
            DropForeignKey("dbo.ArticuloPedido", "ArticuloID", "dbo.Articulo");
            DropIndex("dbo.Pedido", new[] { "ClienteID" });
            DropIndex("dbo.ArticuloPedido", new[] { "ArticuloID" });
            DropIndex("dbo.ArticuloPedido", new[] { "PedidoID" });
            DropTable("dbo.Cliente");
            DropTable("dbo.Pedido");
            DropTable("dbo.Articulo");
            DropTable("dbo.ArticuloPedido");
        }
    }
}
