using ApiTestFramework.Models;
using FluentAssertions;
using FluentAssertions.Common;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using TestFramework.Core.Helpers;

namespace ApiTestFramework.Tests
{
    [TestClass]
    public class APITest
    {
        private RestClient restClient;

        public APITest()
        {
            restClient = new RestClient(ConfiguationHelper.GetValue<string>("url"));
        }

        [TestMethod("TC01: Get User")]
        public void TestGetUser()
        {
            var random = new Random();
            var randomId = random.Next(1, 11);
            
            RestRequest request = new RestRequest($"/api/users/{randomId}", Method.Get);

            // Gọi api và get response
            RestResponse response = restClient.ExecuteGet(request);

            // Verify status
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Verify body
            var body = response.Content;
            var userObj = JsonConvert.DeserializeObject<GetUserReponse.Root>(body);
            userObj.data.id.Should().Be(randomId);
        }

        [TestMethod("TC02: Add user")]
        public void TestCreateUser()
        {
            var random = new Random();
            var randomId = random.Next(1, 11);

            RestRequest request = new RestRequest($"/api/users", Method.Post);
            var bodyRequest = new AddUserRequest
            {
                name = $"vinhpn4-{randomId}",
                job = "qa automation"
            };
            request.AddBody(bodyRequest);

            // Gọi api và get response
            RestResponse response = restClient.ExecutePost(request);

            // Verify status
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var body = response.Content;
            var userObj = JsonConvert.DeserializeObject<AddUserReponse>(body);
            userObj.name.Should().Be(bodyRequest.name);
        }
    }
}
