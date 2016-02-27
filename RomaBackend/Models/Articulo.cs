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
		public Categoria Categoria { get; set; }
	}

	public enum Categoria
	{
		Carne,			//0
		Pollo,			//1
		Salchicha,		//2
		Tortilla,		//3
		Verduras,		//4
		Queso,			//5
		Empalmes,		//6
		Salsa,			//7
		Botana,			//8
		Refrescos,		//9
		Cerveza,		//10
		Desechables,	//11
		Carbon,			//12
		Hielo,			//13
	}
}