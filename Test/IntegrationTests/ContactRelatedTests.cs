using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Account;
using Newtonsoft.Json;
using Xunit;

namespace IntegrationTests
{
    public class ContactRelatedTests : IClassFixture<WebTestFixture>
    {
        private readonly HttpClient _client;
        private String _token;
        private String _id;


        public ContactRelatedTests(WebTestFixture factory)
        {
            _client = factory.CreateClient();
        }


        [Fact]
        public async Task TestCheckIfAdressSeededAsync()
        {

            _client.DefaultRequestHeaders.Add("origin", "https://localhost:44353");

            var response = await _client.PostAsync("/api/Account/authenticate", new StringContent(
            "{\"email\":\"basicuser@gmail.com\",\"password\":\"123Pa$$word!\"}", Encoding.UTF8, "application/json"));
            //response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            dynamic tokenObject = JsonConvert.DeserializeObject(stringResponse);

            _token = tokenObject.data.jwToken;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            response = await _client.GetAsync("/api/v1/Contact/1");
            response.EnsureSuccessStatusCode();
            stringResponse = await response.Content.ReadAsStringAsync();
            Assert.Contains("succeeded", stringResponse);

        }




        //[Fact]
        //public async Task StartReservationTest()
        //{
        //    _client.DefaultRequestHeaders.Add("origin", "https://localhost:44353");

        //    var response = await _client.PostAsync("/api/Account/authenticate", new StringContent(
        //    "{\"email\":\"kamfatima1@gmail.com\",\"password\":\"123Password!\"}", Encoding.UTF8, "application/json"));


        //    var stringResponse = await response.Content.ReadAsStringAsync();
        //    dynamic tokenObject = JsonConvert.DeserializeObject(stringResponse);
        //    _token = tokenObject.data.jwToken;
        //    _id = tokenObject.data.id;
        //    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

        //    StringContent httpConent = new StringContent(JsonConvert.SerializeObject(new StartReservationCommand() { 
        //    ScooterBarcode = "SM071100"
        //    }), Encoding.UTF8, "application/json");

        //    response = await _client.PostAsync("/api/v1/Reservation/StartReservationCommand", httpConent);
        //    response.EnsureSuccessStatusCode();
        //    stringResponse = await response.Content.ReadAsStringAsync();
        //    Assert.Contains("true", stringResponse);
        //}

        //[Fact]
        //public async Task EndReservationTest()
        //{
        //    _client.DefaultRequestHeaders.Add("origin", "https://localhost:44353");

        //    var response = await _client.PostAsync("/api/Account/authenticate", new StringContent(
        //    "{\"email\":\"kamfatima1@gmail.com\",\"password\":\"123Password!\"}", Encoding.UTF8, "application/json"));


        //    var stringResponse = await response.Content.ReadAsStringAsync();
        //    dynamic tokenObject = JsonConvert.DeserializeObject(stringResponse);
        //    _token = tokenObject.data.jwToken;
        //    _id = tokenObject.data.id;
        //    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

        //    StringContent httpConent = new StringContent(JsonConvert.SerializeObject(new EndReservationCommand()
        //    {
        //        ScooterBarcode = "SM071100"
        //    }), Encoding.UTF8, "application/json");

        //    response = await _client.PostAsync("/api/v1/Reservation/EndReservationCommand", httpConent);
        //    response.EnsureSuccessStatusCode();
        //    stringResponse = await response.Content.ReadAsStringAsync();
        //    Assert.Contains("true", stringResponse);
        //}

        //[Fact]
        //public async Task GetMyActiveReservationTest()
        //{
        //    _client.DefaultRequestHeaders.Add("origin", "https://localhost:44353");

        //    var response = await _client.PostAsync("/api/Account/authenticate", new StringContent(
        //    "{\"email\":\"kamfatima1@gmail.com\",\"password\":\"123Password!\"}", Encoding.UTF8, "application/json"));


        //    var stringResponse = await response.Content.ReadAsStringAsync();
        //    dynamic tokenObject = JsonConvert.DeserializeObject(stringResponse);
        //    _token = tokenObject.data.jwToken;
        //    _id = tokenObject.data.id;
        //    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

        //    StringContent httpConent = new StringContent(JsonConvert.SerializeObject(new GetMyActiveReservationQuery()), Encoding.UTF8, "application/json");

        //    response = await _client.GetAsync("/api/v1/Reservation/GetMyActiveReservation");
        //    response.EnsureSuccessStatusCode();
        //    stringResponse = await response.Content.ReadAsStringAsync();
        //    Assert.Contains("true", stringResponse);
        //}

        //[Fact]
        //public async Task GetUsersOnActiveReservationTest()
        //{
        //    _client.DefaultRequestHeaders.Add("origin", "https://localhost:44353");

        //    var response = await _client.PostAsync("/api/Account/authenticate", new StringContent(
        //    "{\"email\":\"kamfatima1@gmail.com\",\"password\":\"123Password!\"}", Encoding.UTF8, "application/json"));


        //    var stringResponse = await response.Content.ReadAsStringAsync();
        //    dynamic tokenObject = JsonConvert.DeserializeObject(stringResponse);
        //    _token = tokenObject.data.jwToken;
        //    _id = tokenObject.data.id;
        //    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

        //    StringContent httpConent = new StringContent(JsonConvert.SerializeObject(new StartReservationCommand()), Encoding.UTF8, "application/json");

        //    response = await _client.GetAsync("/api/v1/Reservation/GetUserOnActiveReservation");
        //    response.EnsureSuccessStatusCode();
        //    stringResponse = await response.Content.ReadAsStringAsync();
        //    Assert.Contains("true", stringResponse);
        //}



    }
}
