using System.Collections.Generic;
using Enterprise.Domain.Contracts.Repositories;
using Enterprise.Domain.Entities;
using Enterprise.Domain.Specifications.Orders;
using Enterprise.Infrastructure.Data.DbContexts;

namespace Enterprise.Infrastructure.Data.Repositories
{
	internal class OrderRepository : IOrderRepository
	{
		// Or inheritance?
		private readonly RepositoryBase<Order> _base;

		public OrderRepository(EnterpriseDbContext dbContext)
		{
			_base = new RepositoryBase<Order>(dbContext.Orders);
		}

		public IEnumerable<Order> FindAllActiveOrders()
		{
			return _base.FindAll(OrderSpecifications.ActiveOrder());
		}
	}
}
