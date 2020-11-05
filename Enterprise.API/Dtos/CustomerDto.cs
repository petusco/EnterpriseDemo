using System;
using System.Collections.Generic;

namespace Enterprise.API.Dtos
{
	public class CustomerDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public ICollection<OrderDto> Orders { get; set; }
	}
}
