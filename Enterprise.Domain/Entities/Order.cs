using System;
using Enterprise.Domain.Abstraction;

namespace Enterprise.Domain.Entities
{
	public class Order : IEntityWithIdentity
	{
		public Guid Id { get; set; }
		public string State { get; set; }
		public Guid CustomerId { get; set; }
	}
}
