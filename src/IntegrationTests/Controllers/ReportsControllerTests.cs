using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Application.Reports.Queries.GetDailyRevenue;
using NUnit.Framework;

namespace IntegrationTests.Controllers
{
    [TestFixture]
    public class ReportsControllerTests : BaseControllerTest
    {
        [Test]
        public async Task GetDailyRevenue_WithSomeData_ShouldReturnDailyRevenue()
        {
            var response = await Client.GetAsync("/api/reports/daily-revenue");

            var responseModel = await response.Content.ReadFromJsonAsync<IEnumerable<DailyRevenueModel>>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, responseModel.Count());
        }
        // Rest of the tests...
    }
}
