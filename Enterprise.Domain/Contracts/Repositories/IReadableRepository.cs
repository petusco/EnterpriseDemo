using System.Collections.Generic;
using Enterprise.Domain.Specifications;

namespace Enterprise.Domain.Contracts.Repositories
{
	public interface IReadableRepository<T>
	{
		T Find(Specification<T> specification);
		IEnumerable<T> FindAll(Specification<T> specification);
	}
}
