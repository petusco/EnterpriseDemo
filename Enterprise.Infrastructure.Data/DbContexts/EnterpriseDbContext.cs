using System;
using Enterprise.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Enterprise.Infrastructure.Data.DbContexts
{
	internal class EnterpriseDbContext : DbContext
	{
		public DbSet<Order> Orders { get; set; }

		public EnterpriseDbContext(DbContextOptions<EnterpriseDbContext> options) : base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Order>(entity =>
			{
				entity.HasKey(order => order.Id);
				entity
					.Property(order => order.State)
					.IsRequired();
			});
		}
	}
}
