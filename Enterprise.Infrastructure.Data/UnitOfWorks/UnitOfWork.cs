using Enterprise.Domain.Contracts.Repositories;
using Enterprise.Domain.Contracts.UnitOfWorks;
using Enterprise.Infrastructure.Data.DbContexts;

namespace Enterprise.Infrastructure.Data.UnitOfWorks
{
	internal class UnitOfWork : IUnitOfWork
	{
		private readonly EnterpriseDbContext _dbContext;

		public ICustomerRepository Customers { get; }
		public IOrderRepository Orders { get; }

		public UnitOfWork(EnterpriseDbContext dbContext,
			ICustomerRepository customerRepository,
			IOrderRepository orderRepository)
		{
			_dbContext = dbContext;
			Customers = customerRepository;
			Orders = orderRepository;
		}

		public void Commit()
		{
			_dbContext.SaveChanges();
		}
	}
}
