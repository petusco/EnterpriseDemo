using System;

namespace Enterprise.Domain.Entities
{
	public class Order
	{
		public Guid Id { get; set; }
		public string State { get; set; }
	}
}
