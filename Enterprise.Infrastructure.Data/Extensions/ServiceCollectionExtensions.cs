using Enterprise.Domain.Contracts.Repositories;
using Enterprise.Infrastructure.Data.DbContexts;
using Enterprise.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Enterprise.Infrastructure.Data.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString) =>
			services
				.AddDbContext<EnterpriseDbContext>(options => options.UseSqlServer(connectionString))
				.AddRepositories();

		private static IServiceCollection AddRepositories(this IServiceCollection services) =>
			services.AddScoped<IOrderRepository, OrderRepository>();
	}
}
