using System;
using System.Threading.Tasks;
using Application.Common.Contracts;
using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Persistence
{
    public static class SalesDbContextSeed
    {
        public static async Task SeedSampleDataAsync(SalesDbContext context)
        {
            // Seed, if necessary
            SeedSales(context);

            await context.SaveChangesAsync();
        }

        private static void SeedSales(ISalesDbContext context)
        {
            context.Sales.AddRange(
                new Sale { ArticleNumber = "0000001", Currency = Currency.Euro, DateTimeUtc = DateTime.UtcNow, Price = 10m },
                new Sale { ArticleNumber = "0000001", Currency = Currency.Euro, DateTimeUtc = DateTime.UtcNow, Price = 10m },
                new Sale { ArticleNumber = "0000001", Currency = Currency.Euro, DateTimeUtc = DateTime.UtcNow, Price = 10m },
                new Sale { ArticleNumber = "0000002", Currency = Currency.Euro, DateTimeUtc = DateTime.UtcNow, Price = 10m },
                new Sale { ArticleNumber = "0000002", Currency = Currency.Euro, DateTimeUtc = DateTime.UtcNow, Price = 10m },
                new Sale { ArticleNumber = "0000002", Currency = Currency.Euro, DateTimeUtc = DateTime.UtcNow, Price = 10m },
                new Sale { ArticleNumber = "0000003", Currency = Currency.Euro, DateTimeUtc = DateTime.UtcNow, Price = 10m });
        }
    }
}