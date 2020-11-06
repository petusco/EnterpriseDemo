using System;
using System.Collections.Generic;
using AutoMapper;
using Enterprise.API.Dtos;
using Enterprise.Domain.Contracts.UnitOfWorks;
using Enterprise.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CustomersController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CustomersController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<IEnumerable<CustomerDto>> GetCustomers()
		{
			var customersFromRepo = _unitOfWork.Customers.FindAll();
			return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customersFromRepo));
		}

		[HttpGet("{customerId}", Name = nameof(GetCustomer))]
		public ActionResult<CustomerDto> GetCustomer(Guid customerId)
		{
			var customerFromRepo = _unitOfWork.Customers.FindById(customerId);
			if (customerFromRepo == null)
			{
				return NotFound();
			}
			return Ok(_mapper.Map<CustomerDto>(customerFromRepo));
		}

		[HttpPost]
		public ActionResult<CustomerDto> CreateCustomer(CustomerForCreationDto customer)
		{
			var customerEntity = _mapper.Map<Customer>(customer);
			_unitOfWork.Customers.Add(customerEntity);
			_unitOfWork.Commit();

			var customerToReturn = _mapper.Map<CustomerDto>(customerEntity);
			return CreatedAtRoute(
				routeName: nameof(GetCustomer),
				routeValues: new { customerId = customerToReturn.Id },
				value: customerToReturn);
		}

		[HttpDelete("{customerId}")]
		public ActionResult<CustomerDto> DeleteCustomer(Guid customerId)
		{
			var customerFromRepo = _unitOfWork.Customers.FindById(customerId);
			if (customerFromRepo == null)
			{
				return NotFound();
			}

			_unitOfWork.Customers.Remove(customerFromRepo);
			_unitOfWork.Commit();
			return NoContent();
		}
	}
}
