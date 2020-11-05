using System.Collections.Generic;
using Enterprise.Domain.Entities;

namespace Enterprise.Domain.Contracts.Repositories
{
	public interface ICustomerRepository
	{
		IEnumerable<Customer> FindAll();
	}
}
