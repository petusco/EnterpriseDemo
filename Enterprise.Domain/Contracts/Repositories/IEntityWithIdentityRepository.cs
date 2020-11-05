using System;
using Enterprise.Domain.Abstraction;

namespace Enterprise.Domain.Contracts.Repositories
{
	public interface IEntityWithIdentityRepository<T> where T : IEntityWithIdentity
	{
		T FindById(Guid id);
	}
}
