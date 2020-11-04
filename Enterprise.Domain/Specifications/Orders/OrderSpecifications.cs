using Enterprise.Domain.Entities;

namespace Enterprise.Domain.Specifications.Orders
{
	public static class OrderSpecifications
	{
		public static Specification<Order> ActiveOrder() => new ActiveOrderSpecification();
		public static Specification<Order> ClosedOrder() => new ClosedOrderSpecification();
	}
}
