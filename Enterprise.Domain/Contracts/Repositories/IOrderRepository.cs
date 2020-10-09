using System.Collections.Generic;
using Enterprise.Domain.Entities;

namespace Enterprise.Domain.Contracts.Repositories
{
	public interface IOrderRepository
	{
		IEnumerable<Order> FindAllActiveOrders();
	}
}
