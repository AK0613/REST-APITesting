using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using RestApiTests.Models.Users;
using RestApiTests.Models.Users.Create;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiTests.TestFixtures
{
    internal class UsersTests : TestFixtureBase
    {
        [Test]
        public void GetUsers()
        {
            // Specify the endpoint
            var endpoint = "https://reqres.in/api/users";
            // Use the Model to save information from the response
            var responseBody = ExecuteGetRequest<UsersResponse>(endpoint);

            //Verify 
            responseBody.page.Should().Be(1);

            responseBody.data.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void CreateUsers()
        {
            //Specify endpoint
            var endpoint = "https://reqres.in/api/users";
            // Specify payload and its type (JSON Serialized)
            var payload = new UsersCreateRequest
            {
                name = "James",
                job = "Engineer"
            };

            //Verify response status code

            var responseBody = ExecutePostRequest<UsersCreateResponse>(endpoint, payload);

            responseBody.id.Should().NotBeNullOrEmpty();
        }
    }
}
