using System.Collections.Generic;

namespace Enterprise.Domain.Contracts.Repositories
{
	public interface IEditableEntityRepository<T>
	{
		void Add(T entity);
		void AddRange(IEnumerable<T> entities);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entities);
	}
}
