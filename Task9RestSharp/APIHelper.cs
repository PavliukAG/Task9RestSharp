using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task9RestSharp
{
    public class APIHelper
    {
        public RestClient restClient;
        public RestRequest restRequest;
        public string baseUrl = "http://api.mathjs.org/v4/";

        public dynamic Preparation(RestRequest request, RestClient client)
        {
            request.RequestFormat = DataFormat.Json;
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject(response.Content.ToString());
        }

        public RestClient SetUrl()
        {
            var client = new RestClient(baseUrl);
            return client;
        }

        public RestRequest GetRequest(int num)
        {
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("User-Agent", "Learning RestSharp");
            restRequest.AddParameter("expr", $"sqrt({num})");
            return restRequest;
        }

        public RestRequest PostRequest(int num1, int num2, string symbol)
        {
            var restRequest = new RestRequest(Method.POST);
            var expr = "{" + $"\"expr\" : \"{num1}" + symbol + $"{num2}\"" + "}";
            restRequest.AddJsonBody(expr);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("User-Agent", "Learning RestSharp");
            return restRequest;
        }

        public string Result(dynamic result)
        {
            return result["result"];
        }
    }
}
