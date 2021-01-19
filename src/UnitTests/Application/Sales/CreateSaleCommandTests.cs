using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Sales.Commands.CreateSale;
using Common.DateTime;
using Domain.Enums;
using Infrastructure.Persistence;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace UnitTests.Application.Sales
{
    [TestFixture]
    public class CreateSaleCommandTests : BaseTest
    {
        private Mock<ILogger<CreateSaleCommand>> _logger;
        private SalesDbContext _context;
        private Mock<IDateTimeProvider> _dateTimeProvider;

        private CreateSaleCommand _sut;

        [SetUp]
        public new void SetUp()
        {
            _logger = new Mock<ILogger<CreateSaleCommand>>();
            _context = new SalesDbContext(ContextOptions);
            _dateTimeProvider = new Mock<IDateTimeProvider>();

            _sut = new CreateSaleCommand(_logger.Object, _context, _dateTimeProvider.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task Execute_ShouldSaveChangesToContext()
        {
            var model = new CreateSaleModel { ArticleNumber = "123456", Price = 10m };

            await _sut.Execute(model);

            Assert.AreEqual(1, _context.Sales.Count());
            Assert.AreEqual(model.ArticleNumber, _context.Sales.First().ArticleNumber);
            Assert.AreEqual(model.Price, _context.Sales.First().Price);
        }

        [Test]
        public async Task Execute_ShouldSaveSalesAsEuro()
        {
            var model = new CreateSaleModel { ArticleNumber = "123456", Price = 10m };

            await _sut.Execute(model);

            Assert.AreEqual(Currency.Euro, _context.Sales.First().Currency);
        }

        [Test]
        public async Task Execute_ShouldHaveCorrectSalesDate()
        {
            var testDate = new DateTime(2020, 10, 10);
            _dateTimeProvider.Setup(x => x.UtcNow).Returns(testDate);

            var model = new CreateSaleModel { ArticleNumber = "123456", Price = 10m };

            await _sut.Execute(model);

            Assert.AreEqual(testDate, _context.Sales.First().DateTimeUtc);
        }
    }
}
