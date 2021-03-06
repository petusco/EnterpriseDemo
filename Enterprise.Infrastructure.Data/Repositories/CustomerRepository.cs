using System;
using System.Collections.Generic;
using System.Linq;
using Enterprise.Domain.Contracts.Repositories;
using Enterprise.Domain.Entities;
using Enterprise.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Enterprise.Infrastructure.Data.Repositories
{
	internal class CustomerRepository : ICustomerRepository
	{
		private readonly RepositoryBase<Customer> _base;
		private readonly DbSet<Customer> _dbSet;

		public CustomerRepository(EnterpriseDbContext dbContext)
		{
			_base = new RepositoryBase<Customer>(dbContext.Customers);
			_dbSet = dbContext.Customers;
		}

		public IEnumerable<Customer> FindAll()
		{
			return _dbSet
				.Include(customer => customer.Orders)
				.ToArray();
		}

		public Customer FindById(Guid customerId)
		{
			return _dbSet
				.Include(customer => customer.Orders)
				.Where(customer => customer.Id == customerId)
				.SingleOrDefault();
		}

		public void Add(Customer entity)
		{
			_base.Add(entity);
		}

		public void AddRange(IEnumerable<Customer> entities)
		{
			_base.AddRange(entities);
		}

		public void Remove(Customer entity)
		{
			_base.Remove(entity);
		}

		public void RemoveRange(IEnumerable<Customer> entities)
		{
			_base.RemoveRange(entities);
		}
	}
}
