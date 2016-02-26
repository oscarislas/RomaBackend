using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using RomaBackend.DataAccessLayer;
using RomaBackend.Models;

namespace RomaBackend.Controllers
{
    public class DataBaseController : ApiController
    {
		[System.Web.Http.HttpGet]
		public Cliente GetCliente(string id)
		{
			Cliente cliente;
			using (var context = new BackendContext())
			{
				cliente = context.Clientes.FirstOrDefault(c => c.Clave.ToLower().Equals(id.ToLower()));
			}
			return cliente;
		}

		[System.Web.Http.HttpGet]
		public Pedido[] GetPedidosCliente(string id)
		{
			Cliente cliente;
			Pedido[] pedidos; 
			using (var context = new BackendContext())
			{
				context.Configuration.ProxyCreationEnabled = false;
				cliente = context.Clientes.FirstOrDefault(c => c.Clave.ToLower().Equals(id.ToLower()));
				pedidos = context.Pedidos.Where(p => p.ClienteID == cliente.ID).Include(p=> p.ArticulosPedidos).ToArray();
			}
			return pedidos;
		}

		[System.Web.Http.HttpGet]
		public Pedido[] GetUltimoPedidoCliente(string id)
		{
			Cliente cliente;
			Pedido[] pedidos;
			using (var context = new BackendContext())
			{
				context.Configuration.ProxyCreationEnabled = false;
				cliente = context.Clientes.FirstOrDefault(c => c.Clave.ToLower().Equals(id.ToLower()));
				pedidos = context.Pedidos.Where(p => p.ClienteID == cliente.ID)
					.OrderByDescending(p=> p.FechaPedido)
					.Take(1)
					.Include(p => p.ArticulosPedidos)
					.ToArray();
			}
			return pedidos;
		}


	    [System.Web.Http.HttpGet]
	    public List<Articulo> GetArticulos()
		{
			List<Articulo> articulos;
			using (var context = new BackendContext())
			{
				articulos = context.Articulos.ToList();
			}
			return articulos;
		}

	}
}