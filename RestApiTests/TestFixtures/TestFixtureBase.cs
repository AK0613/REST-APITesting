using Newtonsoft.Json;
using RestApiTests.Models.Users.Create;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiTests.TestFixtures
{
    abstract class TestFixtureBase
    {
        // Abstract class that lets you send a Get request to a specific endpoint
        protected T ExecuteGetRequest<T>(string endpoint)
        {
            // Setup
            var client = new RestClient(endpoint);
            var request = new RestRequest();
            request.Method = Method.Get;

            //Execute the Get request
            var response = client.Execute(request);
            //Extract the response body and add it to the variable
            var responseBody = JsonConvert.DeserializeObject<T>(response.Content);
            return responseBody;
        }

        /// <summary>
        /// Executes a Post request to a specific endpoint with a certain Payload
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"> The endpoint to talk to the API </param>
        /// <param name="payload"> The JSON payload that needs to be sent with the request</param>
        /// <returns></returns>
        protected T ExecutePostRequest<T, V>(string endpoint, V payload) where V : class
        {
            // Setup
            var client = new RestClient(endpoint);
            var request = new RestRequest();
            request.Method = Method.Post;
            //Extra step to add the payload to the POST request
            request.AddJsonBody(payload);

            var response = client.Execute(request);
            var responseBody = JsonConvert.DeserializeObject<T>(response.Content);
            return responseBody;
        }


    }
}
