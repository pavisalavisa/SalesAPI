using System;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence;

namespace IntegrationTests.Utilities
{
    public static class TestDataSeeder
    {
        public static void Seed(SalesDbContext context)
        {
            SeedSales(context);

            context.SaveChanges();
        }

        private static void SeedSales(SalesDbContext context)
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
