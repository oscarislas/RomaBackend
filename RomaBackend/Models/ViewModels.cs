using System;
using System.Collections.Generic;

namespace RomaBackend.Models
{
	public class PedidoViewModel
	{
		public Guid ClientID { get; set; }
		public List<ArticuloViewModel> List { get; set; }
	}

	public class ArticuloViewModel
	{
		public Guid ID { get; set; }
		public decimal Cantidad { get; set; }
	}
}