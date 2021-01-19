using Application.Reports.Queries.GetDailyRevenue;
using Application.Reports.Queries.GetDailySoldArticles;
using Application.Reports.Queries.GetRevenuePerArticle;
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
            services.AddScoped<IGetRevenuePerArticleQuery, GetRevenuePerArticleQuery>();
            services.AddScoped<IGetDailySoldArticlesQuery, GetDailySoldArticlesQuery>();

            return services;
        }
    }
}
