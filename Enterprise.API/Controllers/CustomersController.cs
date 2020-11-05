using System.Collections.Generic;
using System.Linq;
using Enterprise.API.Dtos;
using Enterprise.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CustomersController : ControllerBase
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomersController(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		[HttpGet]
		public ActionResult<IEnumerable<CustomerDto>> GetCustomers()
		{
			var dtos = _customerRepository.FindAll()
				.Select(customer => new CustomerDto
				{
					Id = customer.Id,
					Name = $"{customer.FirstName} {customer.LastName}",
					Orders = customer.Orders
						.Select(order => new OrderDto
						{
							Id = order.Id,
							State = order.State,
							CustomerId = order.CustomerId
						})
						.ToArray()
				});
			return Ok(dtos);
		}
	}
}
