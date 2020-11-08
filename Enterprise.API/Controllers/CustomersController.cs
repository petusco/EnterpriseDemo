using System;
using System.Collections.Generic;
using AutoMapper;
using Enterprise.API.Dtos;
using Enterprise.Domain.Contracts.UnitOfWorks;
using Enterprise.Domain.Entities;
using Microsoft.AspNetCore.Http;
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
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<IEnumerable<CustomerDto>> GetCustomers()
		{
			var customersFromRepo = _unitOfWork.Customers.FindAll();
			return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customersFromRepo));
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
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

		[HttpGet("{customerId}", Name = nameof(GetCustomer))]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<CustomerDto> GetCustomer(Guid customerId)
		{
			var customerFromRepo = _unitOfWork.Customers.FindById(customerId);
			if (customerFromRepo == null)
			{
				return NotFound();
			}
			return Ok(_mapper.Map<CustomerDto>(customerFromRepo));
		}

		[HttpDelete("{customerId}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult DeleteCustomer(Guid customerId)
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
