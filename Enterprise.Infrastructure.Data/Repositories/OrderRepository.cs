using System.Collections.Generic;
using Enterprise.Domain.Contracts.Repositories;
using Enterprise.Domain.Entities;
using Enterprise.Domain.Specifications.Orders;

namespace Enterprise.Infrastructure.Data.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		// Or inheritance?
		private readonly RepositoryBase<Order> _base;

		public OrderRepository(List<Order> entities)
		{
			_base = new RepositoryBase<Order>(entities);
		}

		public IEnumerable<Order> FindAllActiveOrders()
		{
			return _base.FindAll(OrderSpecifications.ActiveOrder);
		}
	}
}
