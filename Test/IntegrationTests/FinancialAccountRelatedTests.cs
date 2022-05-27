using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
//using EScooterON.WebApi.Application.Features.FinancialAccounts.Queries.GetAllDeletedFinancialAccounts;
//using EScooterON.WebApi.Application.Features.FinancialAccounts.Queries.GetAllFinancialAccounts;
//using EScooterON.WebApi.Application.Features.FinancialAccounts.Queries.GetMyFinancialAccountInfo;
//using EScooterON.WebApi.Application.Features.Trips.Commands.AddTripImage;
//using EScooterON.WebApi.Application.Features.Trips.Commands.EndTrip;
//using EScooterON.WebApi.Application.Features.Trips.Commands.StartTrip;
using Newtonsoft.Json;
using Xunit;

namespace IntegrationTests
{
    public class FinancialAccountRelatedTests : IClassFixture<WebTestFixture>
    {
        private readonly HttpClient _client;
        private String _token;
        private String _id;


        public FinancialAccountRelatedTests(WebTestFixture factory)
        {
            _client = factory.CreateClient();
        }

        //[Fact]
        //public async Task GetAllFinancialAccountsTest()
        //{
        //    _client.DefaultRequestHeaders.Add("origin", "https://localhost:44353");

        //    var response = await _client.PostAsync("/api/Account/authenticate", new StringContent(
        //    "{\"email\":\"kamfatima1@gmail.com\",\"password\":\"123Password!\"}", Encoding.UTF8, "application/json"));


        //    var stringResponse = await response.Content.ReadAsStringAsync();
        //    dynamic tokenObject = JsonConvert.DeserializeObject(stringResponse);
        //    _token = tokenObject.data.jwToken;
        //    _id = tokenObject.data.id;
        //    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

        //    StringContent httpConent = new StringContent(JsonConvert.SerializeObject(new GetAllFinancialAccountsQuery()), Encoding.UTF8, "application/json");

        //    response = await _client.GetAsync("/api/v1/FinancialAccount/getAllFinancialAccounts");
        //    response.EnsureSuccessStatusCode();
        //    stringResponse = await response.Content.ReadAsStringAsync();
        //    Assert.Contains("true", stringResponse);
        //}
        //[Fact]
        //public async Task GetMyFinancialAccountInfoTest()
        //{
        //    _client.DefaultRequestHeaders.Add("origin", "https://localhost:44353");

        //    var response = await _client.PostAsync("/api/Account/authenticate", new StringContent(
        //    "{\"email\":\"kamfatima1@gmail.com\",\"password\":\"123Password!\"}", Encoding.UTF8, "application/json"));


        //    var stringResponse = await response.Content.ReadAsStringAsync();
        //    dynamic tokenObject = JsonConvert.DeserializeObject(stringResponse);
        //    _token = tokenObject.data.jwToken;
        //    _id = tokenObject.data.id;
        //    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

        //    StringContent httpConent = new StringContent(JsonConvert.SerializeObject(new GetMyFinancialAccountInfoQuery()), Encoding.UTF8, "application/json");

        //    response = await _client.GetAsync("/api/v1/FinancialAccount/GetMyFinancialAccountInfo");
        //    response.EnsureSuccessStatusCode();
        //    stringResponse = await response.Content.ReadAsStringAsync();
        //    Assert.Contains("true", stringResponse);
        //}
        //[Fact]
        //public async Task GetAllDeletedFinancialAccountsTest()
        //{
        //    _client.DefaultRequestHeaders.Add("origin", "https://localhost:44353");

        //    var response = await _client.PostAsync("/api/Account/authenticate", new StringContent(
        //    "{\"email\":\"kamfatima1@gmail.com\",\"password\":\"123Password!\"}", Encoding.UTF8, "application/json"));


        //    var stringResponse = await response.Content.ReadAsStringAsync();
        //    dynamic tokenObject = JsonConvert.DeserializeObject(stringResponse);
        //    _token = tokenObject.data.jwToken;
        //    _id = tokenObject.data.id;
        //    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

        //    StringContent httpConent = new StringContent(JsonConvert.SerializeObject(new GetAllDeletedFinancialAccountsQuery()), Encoding.UTF8, "application/json");

        //    response = await _client.GetAsync("/api/v1/FinancialAccount/getAllDeletedFinancialAccounts");
        //    response.EnsureSuccessStatusCode();
        //    stringResponse = await response.Content.ReadAsStringAsync();
        //    Assert.Contains("true", stringResponse);
        //}
    }
}
