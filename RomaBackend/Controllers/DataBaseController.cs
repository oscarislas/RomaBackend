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
					else if (String.IsNullOrEmpty(cliente.Clave))
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
		public Result CreatePedido([FromBody]PedidoViewModel pedidoViewModel, [FromUri]bool ignorarExistencias = false)
		{
			var result = new Result { IsError = false, Message = "Pedido Creado" };
			try
			{
				var pedido = new Pedido
				{
					ID = Guid.NewGuid(),
					ClienteID = pedidoViewModel.ClientID,
					FechaPedido = DateTime.Now,
					Status = Status.PorSurtir,
					Json = pedidoViewModel.Json,
				};
				var articulosPedidos = pedidoViewModel.Articulos.Select(a =>
					new ArticuloPedido
					{
						ArticuloID = a.ID,
						Cantidad = a.Cantidad,
						PedidoID = pedido.ID,
						Indicaciones = a.Indicaciones,
					})
					.ToList();
				pedido.ArticulosPedidos = articulosPedidos;
				using (var context = new BackendContext())
				{
					var articulosIDs = articulosPedidos.Select(ap => ap.ArticuloID).ToList();
                    var articulosToUpdate = context.Articulos.Where(a => articulosIDs.Contains(a.ID)).ToList();
					foreach (var articulo in articulosToUpdate)
					{
						articulo.Existencia -= articulosPedidos.First(a => a.ArticuloID == articulo.ID).Cantidad;

						if (ignorarExistencias || articulo.Existencia >= 0) continue;

						result.IsError = true;
						result.Message = $"No hay suficientes existencias de \"{articulo.Descripcion}\" para el pedido";
						return result;
					}

					context.Pedidos.Add(pedido);
					context.SaveChanges();
				}
				return result;
			}
			catch (Exception e)
			{
				result.IsError = true;
				result.Message = e.Message;
				return result;
			}
		}

		[HttpPost]
		public Result UpdatePedido(PedidoViewModel pedidoViewModel)
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