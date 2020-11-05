using System;

namespace Enterprise.Domain.Abstraction
{
	public interface IEntityWithIdentity
	{
		Guid Id { get; set; }
	}
}
