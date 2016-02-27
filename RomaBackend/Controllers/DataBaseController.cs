using System;
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
		[HttpGet]
		public Cliente GetCliente(string id)
		{
			Cliente cliente;
			using (var context = new BackendContext())
			{
				cliente = context.Clientes.FirstOrDefault(c => c.Clave.ToLower().Equals(id.ToLower()));
			}
			return cliente;
		}

		[HttpGet]
		public Cliente[] GetClientes()
		{
			Cliente[] clientes;
			using (var context = new BackendContext())
			{
				clientes = context.Clientes.ToArray();
			}
			return clientes;
		}

		[HttpPost]
		public Result CreateCliente([FromBody]Cliente cliente)
		{
			var result = new Result { IsError = false, Message = "Cliente creado" };
			try
			{
				using (var context = new BackendContext())
				{
					if (context.Clientes.Any(c => c.Clave == cliente.Clave))
					{
						result.IsError = true;
						result.Message = "Client already exists.";
					}
					else if(String.IsNullOrEmpty(cliente.Clave))
					{
						result.IsError = true;
						result.Message = "La clave no puede ser nula";
					}
					else
					{
						cliente.ID = Guid.NewGuid();
						context.Clientes.Add(cliente);
						context.SaveChanges();
					}
				}
				return result;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				result.IsError = true;
				result.Message = e.Message;
				return result;
			}
		}

		[HttpPost]
		public Result UpdateCliente([FromBody]Cliente cliente)
		{
			var result = new Result { IsError = false, Message = "Cliente actualizado" };
			try
			{
				using (var context = new BackendContext())
				{
					var clientToUpdate = context.Clientes.FirstOrDefault(c => c.Clave == cliente.Clave);
					if (clientToUpdate == null)
					{
						result.IsError = true;
						result.Message = "Cliente no encontrado";
					}
					else
					{
						cliente.ID = clientToUpdate.ID;
						var entry = context.Entry(clientToUpdate);
						entry.CurrentValues.SetValues(cliente);
						context.SaveChanges();
					}
				}
				return result;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				result.IsError = true;
				result.Message = e.Message;
				return result;
			}
		}

		[HttpGet]
		public Pedido[] GetPedidosCliente(string id)
		{
			Cliente cliente;
			Pedido[] pedidos;
			using (var context = new BackendContext())
			{
				context.Configuration.ProxyCreationEnabled = false;
				cliente = context.Clientes.FirstOrDefault(c => c.Clave.ToLower().Equals(id.ToLower()));
				pedidos = context.Pedidos.Where(p => p.ClienteID == cliente.ID).Include(p => p.ArticulosPedidos).ToArray();
			}
			return pedidos;
		}

		[HttpGet]
		public Pedido GetUltimoPedidoCliente(string id)
		{
			Cliente cliente;
			Pedido[] pedidos;
			using (var context = new BackendContext())
			{
				context.Configuration.ProxyCreationEnabled = false;
				cliente = context.Clientes.FirstOrDefault(c => c.Clave.ToLower().Equals(id.ToLower()));
				pedidos = context.Pedidos.Where(p => p.ClienteID == cliente.ID)
					.OrderByDescending(p => p.FechaPedido)
					.Take(1)
					.Include(p => p.ArticulosPedidos)
					.ToArray();
			}
			return pedidos.FirstOrDefault();
		}

		[HttpPost]
		public Result CreatePedido(PedidoViewModel pedido)
		{
			var result = new Result {IsError = false, Message = "Pedido Creado"};
			return result;
		}

		[HttpPost]
		public Result UpdatePedido(PedidoViewModel pedido)
		{
			var result = new Result { IsError = false, Message = "Pedido Actualizado" };
			return result;
		}

		[HttpGet]
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