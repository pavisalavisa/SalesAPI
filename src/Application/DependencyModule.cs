using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddScoped<ICommand>(provider => provider.GetService<Command>());

            return services;
        }
    }
}
