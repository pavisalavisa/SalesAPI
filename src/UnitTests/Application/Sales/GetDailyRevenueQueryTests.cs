using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Reports.Queries.GetDailyRevenue;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence;
using NUnit.Framework;

namespace UnitTests.Application.Sales
{
    [TestFixture]
    public class GetDailyRevenueQueryTests : BaseTest
    {
        private SalesDbContext _context;

        private GetDailyRevenueQuery _sut;

        [SetUp]
        public new void SetUp()
        {
            _context = new SalesDbContext(ContextOptions);

            _sut = new GetDailyRevenueQuery(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task Execute_WithNoSales_ShouldReturnEmptyList()
        {
            var result = await _sut.Execute();

            Assert.IsEmpty(result);
        }

        [Test]
        public async Task Execute_WithSingleSale_ShouldHaveCorrectDateAndPrice()
        {
            var sale = new Sale
            {
                ArticleNumber = "123456",
                Currency = Currency.Euro,
                DateTimeUtc = new DateTime(2020, 10, 10),
                Price = 10m
            };

            Seed(sale);

            var result = await _sut.Execute();

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(10m, result.First().Revenue);
            Assert.AreEqual(new DateTime(2020, 10, 10), result.First().DateTime);
        }
    }
}