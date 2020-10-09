using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Enterprise.Infrastructure.Data.Repositories.Components
{
	internal class ReadableRepositoryComponent<T>
	{
		private readonly List<T> _entities;

		public ReadableRepositoryComponent(List<T> entities)
		{
			_entities = entities;
		}

		public T Find(Expression<Func<T, bool>> expression)
		{
			return _entities
				.Where(expression.Compile())
				.FirstOrDefault();
		}

		public IEnumerable<T> FindAll(Expression<Func<T, bool>> expression)
		{
			return _entities
				.Where(expression.Compile())
				.ToArray();
		}
	}
}
