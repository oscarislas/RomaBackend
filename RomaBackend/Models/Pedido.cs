using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RomaBackend.Models
{
	public class Pedido
	{
		public Guid ID { get; set; }
		[ForeignKey("Cliente")]
		public Guid ClienteID { get; set; }

		public DateTime FechaPedido { get; set; }
		public DateTime? FechaEntrega { get; set; }
		public Status Status { get; set; }
		public string Json { get; set; }

		public virtual List<ArticuloPedido>  ArticulosPedidos{ get; set; }
		public virtual Cliente Cliente { get; set; }
	}

	public enum Status
	{
		PorSurtir,
		Surtido,
		Pagado,
		Cancelado,
		Enviado,
		Entregado,
		Devuelto,
	}
}