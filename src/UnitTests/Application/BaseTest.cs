using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace UnitTests.Application
{
    // Nice conversation starter :)
    // Alternatives to in memory database for unit tests
    public abstract class BaseTest
    {
        protected DbContextOptions<SalesDbContext> ContextOptions;
        
        private const string TestDbName = "TestSalesDatabase";

        protected BaseTest()
        {
            ContextOptions = new DbContextOptionsBuilder<SalesDbContext>()
                .UseInMemoryDatabase(TestDbName).Options;
        }

        [SetUp]
        public void SetUp()
        {
            using var context = new SalesDbContext(ContextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
        
        protected void Seed<T>(params T[] entities)
        {
            using var context = new SalesDbContext(ContextOptions);
            {
                foreach (var entity in entities)
                {
                    context.Add(entity);
                }
                
                context.SaveChanges();
            }
        }
    }
}
