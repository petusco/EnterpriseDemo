using System.Collections.Generic;
using AutoMapper;
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
		private readonly IMapper _mapper;

		public OrdersController(IOrderRepository orderRepository, IMapper mapper)
		{
			_orderRepository = orderRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<IEnumerable<OrderDto>> GetActiveOrders()
		{
			var ordersFromRepo = _orderRepository.FindAllActiveOrders();
			return Ok(_mapper.Map<IEnumerable<OrderDto>>(ordersFromRepo));
		}
	}
}
