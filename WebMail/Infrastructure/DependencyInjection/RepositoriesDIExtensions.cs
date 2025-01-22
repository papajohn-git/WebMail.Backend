using WebMail.Infrastructure.UnitOfWork;

namespace WebMail.Infrastructure.DependencyInjection
{
    public static class RepositoriesDIExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
			services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
			return services;
        }
    }
}
