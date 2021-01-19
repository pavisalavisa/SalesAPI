using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Application.Common;
using Application.Sales.Commands.CreateSale;
using NUnit.Framework;

namespace IntegrationTests.Controllers
{
    [TestFixture]
    public class SalesControllerControllerTests : BaseControllerTest
    {
        [Test]
        public async Task Post_WithCorrectModel_ShouldCreateSale()
        {
            var model = new CreateSaleModel { ArticleNumber = "123456", Price = 10m };
            var response = await Client.PostAsync("/api/sales", JsonContent.Create(model));

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual(8, (await response.Content.ReadFromJsonAsync<EntityCreatedModel>()).Id); // 7 values are already seeded so we expect this to be 8th value
        }
    }
}