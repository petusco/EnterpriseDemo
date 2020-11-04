using System;
using System.Linq.Expressions;
using Enterprise.Domain.Entities;

namespace Enterprise.Domain.Specifications.Orders
{
	public class ClosedOrderSpecification : Specification<Order>
	{
		public override Expression<Func<Order, bool>> ToExpression()
		{
			return order => order.State == "Closed";
		}
	}
}
