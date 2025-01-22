using WebMail.Application.Mappings;
using WebMail.Application.Services.Implementations;
using WebMail.Application.Services.Interfaces;

namespace WebMail.Application.DependencyInjection
{
	public static class ServiceContainerDI
	{
		public static IServiceCollection RegisterServices(this IServiceCollection services)
		{
			services.AddScoped<IApplicationService, ApplicationService>();
			return services;
		}
	}
}
