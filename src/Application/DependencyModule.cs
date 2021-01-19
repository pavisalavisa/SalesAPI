using Application.Reports.Queries.GetDailyRevenue;
using Application.Sales.Commands.CreateSale;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreateSaleCommand, CreateSaleCommand>();
            services.AddScoped<IGetDailyRevenueQuery, GetDailyRevenueQuery>();

            return services;
        }
    }
}
