using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
//using EScooterON.WebApi.Application.Features.Notifications.Queries.GetUserNotifications;
using Newtonsoft.Json;
using Xunit;

namespace IntegrationTests
{
    public class NotificationRelatedTests : IClassFixture<WebTestFixture>
    {
        private readonly HttpClient _client;
        private String _token;
        private String _id;


        public NotificationRelatedTests(WebTestFixture factory)
        {
            _client = factory.CreateClient();
        }



        //[Fact]
        //public async Task GetUserNotificationsTest()
        //{
        //    _client.DefaultRequestHeaders.Add("origin", "https://localhost:44353");

        //    var response = await _client.PostAsync("/api/Account/authenticate", new StringContent(
        //    "{\"email\":\"kamfatima1@gmail.com\",\"password\":\"123Password!\"}", Encoding.UTF8, "application/json"));


        //    var stringResponse = await response.Content.ReadAsStringAsync();
        //    dynamic tokenObject = JsonConvert.DeserializeObject(stringResponse);
        //    _token = tokenObject.data.jwToken;
        //    _id = tokenObject.data.id;
        //    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

        //    StringContent httpConent = new StringContent(JsonConvert.SerializeObject(new GetUserNotificationsQuery()), Encoding.UTF8, "application/json");

        //    response = await _client.GetAsync("/api/v1/Notification/GetUserNotifications");
        //    response.EnsureSuccessStatusCode();
        //    stringResponse = await response.Content.ReadAsStringAsync();
        //    Assert.Contains("true", stringResponse);
        //}

        //[Fact]
        //public async Task GetUsersNotReceivedNotificationsTest()
        //{
        //    _client.DefaultRequestHeaders.Add("origin", "https://localhost:44353");

        //    var response = await _client.PostAsync("/api/Account/authenticate", new StringContent(
        //    "{\"email\":\"kamfatima1@gmail.com\",\"password\":\"123Password!\"}", Encoding.UTF8, "application/json"));


        //    var stringResponse = await response.Content.ReadAsStringAsync();
        //    dynamic tokenObject = JsonConvert.DeserializeObject(stringResponse);
        //    _token = tokenObject.data.jwToken;
        //    _id = tokenObject.data.id;
        //    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

        //    StringContent httpConent = new StringContent(JsonConvert.SerializeObject(new GetUsersNotReceivedNotificationsQuery()), Encoding.UTF8, "application/json");

        //    response = await _client.GetAsync("/api/v1/Notification/GetUsersNotReceivedNotifications");
        //    response.EnsureSuccessStatusCode();
        //    stringResponse = await response.Content.ReadAsStringAsync();
        //    Assert.Contains("true", stringResponse);
        //}


    }
}
