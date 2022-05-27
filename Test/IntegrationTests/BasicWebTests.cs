using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Account;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace IntegrationTests
{
    public class BasicWebTests : IClassFixture<WebTestFixture>
    {
        private readonly HttpClient _client;
        private String _token;

        public BasicWebTests(WebTestFixture factory)
        {
            _client = factory.CreateClient();
        }


        [Fact]
        public async Task TestLogin()
        {

            AuthenticationRequest request = new AuthenticationRequest
            {
                Email = "basicuser@gmail.com",
                Password = "123Pa$$word!"
            };
            var response = await _client.PostAsync("/api/Account/authenticate", new StringContent(
            "{\"email\":\"basicuser@gmail.com\",\"password\":\"123Pa$$word!\"}", Encoding.UTF8, "application/json"));
            //response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            dynamic tokenObject = JsonConvert.DeserializeObject(stringResponse);
            _token = tokenObject.data.jwToken;
            
        }
        /*
        [Fact]
        public async Task TestRegisterShouldReturnError()
        {
            RegisterRequest request = new RegisterRequest
            {
                Email = "basicuser@gmail.com",
                Password = "123Pa$$word!",
                ConfirmPassword = "123Pa$$word!",
                FirstName = "Taha",
                LastName = "Alkan",
                UserName = "basicuser"
            };

            var jsonRequest = JsonConvert.SerializeObject(request);
            var response = await _client.PostAsync("/api/Account/register", new StringContent(
            jsonRequest, Encoding.UTF8, "application/json"));
            //response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
            Assert.Contains("already taken", stringResponse);

        }
        */
        [Fact]
        public async Task TestCreateProductAsync()
        {
            AuthenticationRequest request = new AuthenticationRequest
            {
                Email = "basicuser@gmail.com",
                Password = "123Pa$$word!"
            };
            _client.DefaultRequestHeaders.Add("origin", "https://localhost:44353");
                
            var response = await _client.PostAsync("/api/Account/authenticate", new StringContent(
            "{\"email\":\"basicuser@gmail.com\",\"password\":\"123Pa$$word!\"}", Encoding.UTF8, "application/json"));
            //response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            dynamic tokenObject = JsonConvert.DeserializeObject(stringResponse);
           
            _token = tokenObject.data.jwToken;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

             response = await _client.GetAsync("/api/v1/Product");
            response.EnsureSuccessStatusCode();
             stringResponse = await response.Content.ReadAsStringAsync();
            Assert.Contains("succeeded", stringResponse);
        }

        [Fact]
        public async Task TestCreateNewUserFailBecauseOfSamePhoneNumberAsync()
        {
            RegisterRequest registerRequest = new RegisterRequest()
            {
                UserName = "umitulusar",
                LastName = "Ulusar",
                Email = "umitulusar@gmail.com",
                FirstName = "Umit",
                Password = "Password01!",
                ConfirmPassword = "Password01!",
                //DateOfBirth = DateTime.Now,
                //IDNumber = "123213213213",
                //PhoneNumber = "901111111111"
            };

            _client.DefaultRequestHeaders.Add("origin", "https://localhost:44353");

            StringContent httpConent = new StringContent(JsonConvert.SerializeObject(registerRequest), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/Account/register", httpConent);

            var stringResponse = await response.Content.ReadAsStringAsync();
            Assert.Contains("Bu telefon", stringResponse);


        }


        [Fact]
        public async Task TestCreateNewUserFailBecauseOfSameEmailAsync()
        {
            RegisterRequest registerRequest = new RegisterRequest()
            {
                UserName = "umitulusar",
                LastName = "Ulusar",
                Email = "comnets@comnets.com",
                FirstName = "Umit",
                Password = "Password01!",
                ConfirmPassword = "Password01!",
                //DateOfBirth = DateTime.Now,
                //IDNumber = "123213213213",
                //PhoneNumber = "90545435"
            };

            _client.DefaultRequestHeaders.Add("origin", "https://localhost:44353");

            StringContent httpConent = new StringContent(JsonConvert.SerializeObject(registerRequest), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/Account/register", httpConent);
            var stringResponse = await response.Content.ReadAsStringAsync();
            Assert.Contains("Bu e-posta", stringResponse);

        }


        [Fact]
        public async Task TestCreateNewUserFailBecauseOfSameUserNameAsync()
        {
            RegisterRequest registerRequest = new RegisterRequest()
            {
                UserName = "comnets",
                LastName = "Ulusar",
                Email = "comnets@comnets.com",
                FirstName = "Umit",
                Password = "Password01!",
                ConfirmPassword = "Password01!",
                //DateOfBirth = DateTime.Now,
                //IDNumber = "123213213213",
                //PhoneNumber = "905454354543"
            };

            _client.DefaultRequestHeaders.Add("origin", "https://localhost:44353");

            StringContent httpConent = new StringContent(JsonConvert.SerializeObject(registerRequest), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/Account/register", httpConent);
            var stringResponse = await response.Content.ReadAsStringAsync();
            Assert.Contains("kullan", stringResponse);
            //ı gibi karakterler assertte sorun yaratıyor
        }


        [Fact]
        public async Task TestCreateNewUserAndgetNearbyScootersAsync()
        {
            RegisterRequest registerRequest = new RegisterRequest()
            {
                UserName = "umitulusar",
                LastName = "Ulusar",
                Email = "umitulusar@gmail.com",
                FirstName = "Umit",
                Password = "Password01!",
                ConfirmPassword = "Password01!",
                //DateOfBirth = DateTime.Now,
                //IDNumber="123213213213",
                //PhoneNumber="905333268607"
            };

            _client.DefaultRequestHeaders.Add("origin", "https://localhost:44353");

            StringContent httpConent = new  StringContent(JsonConvert.SerializeObject(registerRequest),Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/Account/register", httpConent);
                
            response.EnsureSuccessStatusCode();


            AuthenticationRequest request = new AuthenticationRequest
            {
                Email = "umitulusar@gmail.com",
                Password = "Password01!"
            };
            _client.DefaultRequestHeaders.Add("origin", "https://localhost:44353");

            response = await _client.PostAsync("/api/Account/authenticate", new StringContent(
            "{\"email\":\"umitulusar@gmail.com\",\"password\":\"Password01!\"}", Encoding.UTF8, "application/json"));

            var stringResponse = await response.Content.ReadAsStringAsync();
            dynamic tokenObject = JsonConvert.DeserializeObject(stringResponse);
            _token = tokenObject.data.jwToken;


            // ID yi al phone number ata ardından token al verify et

//          authorize and get token
//            Response<AuthenticationResponse> objectS = (Response<AuthenticationResponse>)JsonConvert.DeserializeObject(stringResponse);

//            AuthenticationResponse _data =(AuthenticationResponse) objectS.Data;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            response = await _client.GetAsync("/api/v1/Scooter/getNearbyScooters");
            response.EnsureSuccessStatusCode();
            stringResponse = await response.Content.ReadAsStringAsync();
            Assert.Contains("Scooter1", stringResponse);
        }


    }
}
