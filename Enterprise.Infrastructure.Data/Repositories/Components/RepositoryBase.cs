using System.Collections.Generic;
using System.Linq;
using Enterprise.Domain.Contracts.Repositories;
using Enterprise.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Enterprise.Infrastructure.Data.Repositories
{
	// Excessive methods like Remove/Delete inherited from this base class may be hidden by the repository
	// Alternative: Use composition
	internal class RepositoryBase<T> : IReadableRepository<T>, IEditableEntityRepository<T> where T : class
	{
		private readonly DbSet<T> _entities;

		public RepositoryBase(DbSet<T> entities)
		{
			_entities = entities;
		}

		public T Find(Specification<T> specification)
		{
			return _entities
				.Where(specification.Predicate)
				.FirstOrDefault();
		}

		public IEnumerable<T> FindAll(Specification<T> specification)
		{
			return _entities
				.Where(specification.Predicate)
				.ToArray();
		}

		public IQueryable<T> AsQueryable()
		{
			return _entities.AsQueryable();
		}

		public void Add(T entity)
		{
			_entities.Add(entity);
		}

		public void AddRange(IEnumerable<T> entities)
		{
			_entities.AddRange(entities);
		}

		public void Remove(T entity)
		{
			_entities.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			foreach (var entity in entities)
			{
				Remove(entity);
			}
		}
	}
}
