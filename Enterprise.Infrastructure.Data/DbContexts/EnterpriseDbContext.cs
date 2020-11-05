using System;
using Enterprise.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Enterprise.Infrastructure.Data.DbContexts
{
	internal class EnterpriseDbContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }

		public EnterpriseDbContext(DbContextOptions<EnterpriseDbContext> options) : base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Customer>(entity =>
			{
				entity
					.Property(customer => customer.FirstName)
					.IsRequired();
				entity
					.Property(customer => customer.LastName)
					.IsRequired();

				entity.HasData(
					new Customer()
					{
						Id = Guid.Parse("6EA0FCDA-5B77-4CD4-8DA6-2ED612A090A5"),
						FirstName = "Carl",
						LastName = "Sagan"
					}
				);
			});

			builder.Entity<Order>(entity =>
			{
				entity
					.Property(order => order.State)
					.IsRequired();
				entity
					.Property(order => order.CustomerId)
					.IsRequired();

				entity.HasData(
					new Order
					{
						Id = Guid.Parse("58E2343C-99CD-44D0-B7F9-8AF56308F0CE"),
						State = "Active",
						CustomerId = Guid.Parse("6EA0FCDA-5B77-4CD4-8DA6-2ED612A090A5")
					},
					new Order
					{
						Id = Guid.Parse("5B9D6E06-4EC3-46A5-A0E3-A9B1495D1A58"),
						State = "Closed",
						CustomerId = Guid.Parse("6EA0FCDA-5B77-4CD4-8DA6-2ED612A090A5")
					}
				);
			});
		}
	}
}
