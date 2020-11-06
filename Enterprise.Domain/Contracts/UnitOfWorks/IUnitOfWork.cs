using Enterprise.Domain.Contracts.Repositories;

namespace Enterprise.Domain.Contracts.UnitOfWorks
{
	public interface IUnitOfWork
	{
		ICustomerRepository Customers { get; }
		IOrderRepository Orders { get; }
		void Commit();
	}
}
