using System.Collections.Generic;
using Enterprise.Domain.Entities;

namespace Enterprise.Domain.Contracts.Repositories
{
	public interface ICustomerRepository : IEntityWithIdentityRepository<Customer>
	{
		IEnumerable<Customer> FindAll();
	}
}
