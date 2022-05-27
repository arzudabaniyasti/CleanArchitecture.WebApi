using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class InventoryRelatedTests : IClassFixture<WebTestFixture>
    {
        private readonly HttpClient _client;
        private String _token;
        private String _id;


        public InventoryRelatedTests(WebTestFixture factory)
        {
            _client = factory.CreateClient();
        }


        [Fact]
        public async Task TestCheckIfInventorySeededAsync()
        {

            _client.DefaultRequestHeaders.Add("origin", "https://localhost:44353");

            var response = await _client.PostAsync("/api/Account/authenticate", new StringContent(
            "{\"email\":\"basicuser@gmail.com\",\"password\":\"123Pa$$word!\"}", Encoding.UTF8, "application/json"));
            //response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            dynamic tokenObject = JsonConvert.DeserializeObject(stringResponse);

            _token = tokenObject.data.jwToken;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            response = await _client.GetAsync("/api/v1/Inventory/1");
            response.EnsureSuccessStatusCode();
            stringResponse = await response.Content.ReadAsStringAsync();
            Assert.Contains("succeeded", stringResponse);

        }

    }
}
