using System.Collections.Generic;
using System.Linq;
using Enterprise.API.Dtos;
using Enterprise.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderRepository _orderRepository;

		public OrdersController(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		[HttpGet]
		public ActionResult<IEnumerable<OrderDto>> GetActiveOrders()
		{
			var orders = _orderRepository.FindAllActiveOrders();
			var dtos = orders.Select(order => new OrderDto { Id = order.Id, State = order.State });
			return Ok(orders);
		}
	}
}
