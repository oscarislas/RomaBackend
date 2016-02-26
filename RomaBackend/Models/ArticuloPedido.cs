using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RomaBackend.Models
{
	public class ArticuloPedido
	{
		[Column(Order = 0), Key, ForeignKey("Pedido")]
		public Guid PedidoID { get; set; }
		[Column(Order = 1), Key, ForeignKey("Articulo")]
		public Guid ArticuloID { get; set; }

		public decimal Cantidad { get; set; }
		[StringLength(200)]
		public string Indicaciones { get; set; }

		public virtual Pedido Pedido { get; set; }
		public virtual Articulo Articulo { get; set; }
	}
}