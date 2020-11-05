using System;

namespace Enterprise.API.Dtos
{
	public class OrderDto
	{
		public Guid Id { get; set; }
		public string State { get; set; }
		public Guid CustomerId { get; set; }
	}
}
