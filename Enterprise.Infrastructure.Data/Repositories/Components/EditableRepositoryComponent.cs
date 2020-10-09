using System.Collections.Generic;

namespace Enterprise.Infrastructure.Data.Repositories.Components
{
	// It can be further decomposed into the two separate components but is it necessary?
	internal class EditableRepositoryComponent<T>
	{
		private readonly List<T> _entities;

		public EditableRepositoryComponent(List<T> entities)
		{
			_entities = entities;
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
