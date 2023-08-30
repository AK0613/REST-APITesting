using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using RestApiTests.Models.Users;
using RestApiTests.Models.Users.Create;
using RestApiTests.Models.Users.Login;
using RestApiTests.Models.Users.Register;
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
        public void GetSpecificUser()
        {
            var url = "https://reqres.in/api/users/";
            var user = "2";
            var endpoint = url + user;

            var responseBody = ExecuteGetRequest<SingleUserResponse>(endpoint);
            responseBody.data.id.Should().Be(2);
            responseBody.data.first_name.Should().Be("Janet");


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

            var responseBody = ExecutePostRequest<UsersCreateResponse, UsersCreateRequest>(endpoint, payload);

            responseBody.id.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void RegisterUser()
        {
            var endpoint = "https://reqres.in/api/register";
            var payload = new RegisterUserRequest
            {
                email = "eve.holt@reqres.in",
                password = "LePass"
            };

            var responseBody = ExecutePostRequest<RegisterUserResponse, RegisterUserRequest>(endpoint, payload);
            responseBody.token.Should().NotBeNull();
        }

        [Test]
        public void Login()
        {
            var endpoint = "https://reqres.in/api/login";
            var payload = new LoginRequest
            {
                email = "eve.holt@reqres.in",
                password = "LePass"
            };

            var responseBody = ExecutePostRequest<LoginResponse, LoginRequest>(endpoint, payload);
            responseBody.token.Should().NotBeNull();
        }

        [Test]
        public void LoginError_Expected()
        {
            var endpoint = "https://reqres.in/api/login";
            var payload = new LoginRequest
            {
                email = "eve.holt@reqres.in",
            };

            var responseBody = ExecutePostRequest<LoginErrorResponse, LoginRequest>(endpoint, payload);
            responseBody.error.Should().Be("Missing password");
        }
    }
}
