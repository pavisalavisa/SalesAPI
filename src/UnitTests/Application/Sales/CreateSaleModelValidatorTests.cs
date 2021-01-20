using Application.Sales.Commands.CreateSale;
using NUnit.Framework;

namespace UnitTests.Application.Sales
{
    [TestFixture]
    public class CreateSaleModelValidatorTests
    {
        private CreateSaleModel.CreateSaleModelValidator _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new CreateSaleModel.CreateSaleModelValidator();
        }

        [Test]
        public void GivenEmptyArticleNumber_Validate_ShouldHaveAValidationError()
        {
            var model = new CreateSaleModel {Price = 10.5m};

            var result = _sut.Validate(model);

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(1,result.Errors.Count);
        }

        [TestCase("000000000000000000000000000000033")]
        [TestCase("0000000000000000000000000000000034")]
        public void GivenTooManyCharactersInArticleNumber_Validate_ShouldHaveAValidationError(string articleNumber)
        {
            var model = new CreateSaleModel { ArticleNumber =articleNumber, Price = 10.5m };

            var result = _sut.Validate(model);

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(1, result.Errors.Count);
        }

        [TestCase("+aaaa")]
        [TestCase("-aaaa")]
        [TestCase(".aaaa")]
        [TestCase("!##aaaa")]
        public void GivenNonAlphaNumArticleNumber_Validate_ShouldHaveAValidationError(string articleNumber)
        {
            var model = new CreateSaleModel { ArticleNumber = articleNumber, Price = 10.5m };

            var result = _sut.Validate(model);

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(1, result.Errors.Count);
        }

        [Test]
        public void GivenNegativePrice_Validate_ShouldHaveAValidationError()
        {
            var model = new CreateSaleModel { ArticleNumber = "000001", Price = -10.5m };

            var result = _sut.Validate(model);

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(1, result.Errors.Count);
        }

        [Test]
        public void GivenValidModel_Validate_ShouldNotHaveAValidationError()
        {
            var model = new CreateSaleModel { ArticleNumber = "000001", Price = 10.5m };

            var result = _sut.Validate(model);

            Assert.IsTrue(result.IsValid);
            Assert.IsEmpty(result.Errors);
        }
    }
}
