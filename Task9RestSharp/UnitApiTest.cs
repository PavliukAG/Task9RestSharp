using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;

namespace Task9RestSharp
{
    [TestFixture]
    public class Tests
    {
        APIHelper apiHelp = new APIHelper();
       
        [TestCase(2, 1, "-", 1)]
        [TestCase(2, 2, "-", 0)]
        [TestCase(-2, 1, "-", -3)]
        [TestCase(2, 1, "+", 3)]
        [TestCase(2, 2, "+", 4)]
        [TestCase(-2, 1, "+", -1)]
        [TestCase(2, 1, "*", 2)]
        [TestCase(2, 2, "*", 4)]
        [TestCase(-2, 1, "*", -2)]
        [TestCase(2, 1, "/", 2)]
        [TestCase(2, 2, "/", 1)]
        [TestCase(-2, 1, "/", -2)]
        public void TestPostRequest(int num1, int num2, string symbol, int expectedResualt)
        {
            var client = apiHelp.SetUrl();            
            var request = apiHelp.PostRequest(num1, num2, symbol);
            dynamic result = apiHelp.Preparation(request, client);
            string actualResult = apiHelp.Result(result);
            Assert.That(actualResult == expectedResualt.ToString());
        }


        [TestCase(9, 3)]
        [TestCase(16, 4)]
        [TestCase(4, 2)]
        public void TestGetSqrtRequest(int num, int expectedResult)
        {
            var client = apiHelp.SetUrl();
            var request = apiHelp.GetRequest(num);
            var actualResult = apiHelp.Preparation(request, client);
            Assert.That(actualResult == expectedResult );
        }
    }
}