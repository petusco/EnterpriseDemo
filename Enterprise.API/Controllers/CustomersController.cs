using System;
using System.Collections.Generic;
using AutoMapper;
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
		private readonly IMapper _mapper;

		public CustomersController(ICustomerRepository customerRepository, IMapper mapper)
		{
			_customerRepository = customerRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<IEnumerable<CustomerDto>> GetCustomers()
		{
			var customersFromRepo = _customerRepository.FindAll();
			return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customersFromRepo));
		}

		[HttpGet("{customerId}")]
		public ActionResult<CustomerDto> GetCustomers(Guid customerId)
		{
			var customerFromRepo = _customerRepository.FindById(customerId);
			if (customerFromRepo == null)
			{
				return NotFound();
			}
			return Ok(_mapper.Map<CustomerDto>(customerFromRepo));
		}
	}
}
