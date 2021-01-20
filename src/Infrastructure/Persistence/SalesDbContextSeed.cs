using System;
using System.Threading.Tasks;
using Application.Common.Contracts;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public static class SalesDbContextSeed
    {
        public static async Task SeedSampleDataAsync(SalesDbContext context)
        {
            // Seed, if necessary
            await SeedSales(context);

            await context.SaveChangesAsync();
        }

        private static async Task SeedSales(ISalesDbContext context)
        {
            if (!(await context.Sales.AnyAsync()))
            {
                await context.Sales.AddRangeAsync(
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
}