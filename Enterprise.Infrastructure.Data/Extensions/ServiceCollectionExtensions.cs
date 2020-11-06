using Enterprise.Domain.Contracts.Repositories;
using Enterprise.Domain.Contracts.UnitOfWorks;
using Enterprise.Infrastructure.Data.DbContexts;
using Enterprise.Infrastructure.Data.Repositories;
using Enterprise.Infrastructure.Data.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Enterprise.Infrastructure.Data.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString) =>
			services
				.AddDbContext<EnterpriseDbContext>(options => options.UseSqlServer(connectionString))
				.AddRepositories()
				.AddUnitOfWorks();

		private static IServiceCollection AddRepositories(this IServiceCollection services) =>
			services
				.AddScoped<ICustomerRepository, CustomerRepository>()
				.AddScoped<IOrderRepository, OrderRepository>();

		private static IServiceCollection AddUnitOfWorks(this IServiceCollection services) =>
			services
				.AddScoped<IUnitOfWork, UnitOfWork>();
	}
}
