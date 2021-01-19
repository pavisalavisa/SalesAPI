﻿using System;
using System.Linq;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IntegrationTests.Utilities
{
    // Nice conversation starter :)
    // What is an integration test and how much of dependencies should be mocked?
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        private const string InMemoryDbName = "IntegratioNTestsInMemoryDb";

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                ReplaceDbContextDependency(services);

                InitializeDatabase(services);
            });
        }

        private static void ReplaceDbContextDependency(IServiceCollection services)
        {
            var descriptor =
                services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<SalesDbContext>));

            services.Remove(descriptor);

            services.AddDbContext<SalesDbContext>(options => { options.UseInMemoryDatabase(InMemoryDbName); });
        }

        private static void InitializeDatabase(IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<SalesDbContext>();
            var logger = scopedServices
                .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            try
            {
                TestDataSeeder.Seed(db);
            }
            catch (Exception ex)
            {
                logger.LogError(ex,
                    $"An error occurred seeding the database with test messages. Error: {ex.Message}");
            }
        }
    }
}