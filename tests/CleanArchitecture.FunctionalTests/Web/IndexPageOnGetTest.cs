using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.FunctionalTests.Web
{
    public class IndexPageOnGetTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        public HttpClient Client { get; }
        public IndexPageOnGetTest(CustomWebApplicationFactory<Program> factory)
        {
            Client = factory.CreateClient();
        }
        [Fact]
        public async Task CheckIndexPageOnGet()
        {
            var response = await Client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            Assert.Contains("Welcome", stringResponse);
        }
    }
}
