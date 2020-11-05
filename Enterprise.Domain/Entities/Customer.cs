using System;
using System.Collections.Generic;
using Enterprise.Domain.Abstraction;

namespace Enterprise.Domain.Entities
{
	public class Customer : IEntityWithIdentity
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}
