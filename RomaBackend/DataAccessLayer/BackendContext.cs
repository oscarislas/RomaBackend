using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RomaBackend.Models;

namespace RomaBackend.DataAccessLayer
{
	public class BackendContext : DbContext
	{

		public BackendContext() : base("BackendContext")
		{
		}

		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<Articulo> Articulos { get; set; }
		public DbSet<Pedido> Pedidos { get; set; }
		public DbSet<ArticuloPedido> ArticuloPedidos { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}