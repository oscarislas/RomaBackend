using System;
using System.Collections.Generic;

namespace RomaBackend.Models
{
	public class PedidoViewModel
	{
		public Guid? ID { get; set; }
		public Guid ClientID { get; set; }
		public Status? Status { get; set; }
		public string Json { get; set; }
		public List<ArticuloViewModel> Articulos { get; set; }
	}

	public class ArticuloViewModel
	{
		public Guid ID { get; set; }
		public decimal Cantidad { get; set; }
		public string Indicaciones { get; set; }
	}
}