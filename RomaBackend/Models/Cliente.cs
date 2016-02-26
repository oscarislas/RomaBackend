using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RomaBackend.Models
{
	public class Cliente
	{
		[Key]
		public Guid ID { get; set; }
		[StringLength(50)]
		[Index("IX_Clave", 1, IsUnique = true)]
		public string Clave { get; set; }
		[StringLength(100)]
		public string Nombre { get; set; }
		[StringLength(200)]
		public string Calle { get; set; }
		[StringLength(100)]
		public string Colonia { get; set; }
		[StringLength(50)]
		public string Ciudad { get; set; }
		[StringLength(50)]
		public string Correo { get; set; }
		[StringLength(500)]
		public string Indicaciones { get; set; }

		[StringLength(20)]
		public string RFC { get; set; }
		[StringLength(100)]
		public string NombreFactura { get; set; }
		[StringLength(200)]
		public string CalleFactura { get; set; }
		[StringLength(100)]
		public string ColoniaFactura { get; set; }
		[StringLength(50)]
		public string CiudadFactura { get; set; }
		[StringLength(50)]
		public string CorreoFactura { get; set; }
	}
}