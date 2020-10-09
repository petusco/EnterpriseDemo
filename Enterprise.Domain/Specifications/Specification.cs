using System;
using System.Linq.Expressions;

namespace Enterprise.Domain.Specifications
{
	public abstract class Specification<T>
	{
		public abstract Expression<Func<T, bool>> ToExpression();

		private Func<T, bool> _predicate;
		public Func<T, bool> Predicate => _predicate ??= ToExpression().Compile();

		public bool IsSatisfiedBy(T entity) => Predicate(entity);

		public Specification<T> And(Specification<T> other) => new AndSpecification<T>(this, other);

		public Specification<T> Or(Specification<T> other) => new OrSpecification<T>(this, other);

		public Specification<T> Not() => new NotSpecification<T>(this);

		public Specification<T> AndNot(Specification<T> other) => And(other.Not());

		public Specification<T> OrNot(Specification<T> other) => Or(other.Not());
	}
}
