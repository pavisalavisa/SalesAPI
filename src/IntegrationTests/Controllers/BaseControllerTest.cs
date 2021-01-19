using System.Net.Http;
using Api;
using IntegrationTests.Utilities;
using NUnit.Framework;

namespace IntegrationTests.Controllers
{
    public abstract class BaseControllerTest
    {
        protected HttpClient Client;
        private CustomWebApplicationFactory<Startup> _factory;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _factory = new CustomWebApplicationFactory<Startup>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _factory.Dispose();
        }

        [SetUp]
        public void SetUp()
        {
            Client = _factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            Client.Dispose();
        }
    }
}
