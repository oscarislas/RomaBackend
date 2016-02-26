using System;
using System.ComponentModel.DataAnnotations;

namespace RomaBackend.Models
{
	public class Articulo
	{
		public Guid ID { get; set; }
		[StringLength(10)]
		public string Code { get; set; }
		[StringLength(50)]
		public string Descripcion { get; set; }
		[StringLength(30)]
		public string Marca { get; set; }
		[StringLength(5)]	
		public string Unidades { get; set; }
		public decimal Precio { get; set; }
		public decimal Existencia { get; set; }
	}
}