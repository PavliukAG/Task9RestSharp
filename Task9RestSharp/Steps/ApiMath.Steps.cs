using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace Task9RestSharp.Steps
{
    [Binding]
    public sealed class ApiMath
    {

        RestClient client;
        private readonly APIHelper helper;
        Calculator calculator;
        private dynamic actualResult;

        public ApiMath(APIHelper helper)
        {
            this.helper = helper;
            calculator = new Calculator();
            client = helper.SetUrl();
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            calculator.FirstNumber = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            calculator.SecondNumber = number;
        }

        [Given(@"the number is (.*)")]
        public void GivenTheNumberIs(int num)
        {
            calculator.Number = num;
        }


        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            var request = helper.PostRequest(calculator.FirstNumber, calculator.SecondNumber, Calculator.Add);
            dynamic result = helper.Preparation(request, client);
            actualResult = helper.Result(result);
        }


        [When(@"the two numbers are subtracted")]
        public void WhenTheTwoNumbersAreSubtracted()
        {
            var request = helper.PostRequest(calculator.FirstNumber, calculator.SecondNumber, Calculator.Subtract);
            dynamic result = helper.Preparation(request, client);
            actualResult = helper.Result(result);
        }

        [When(@"the two numbers are multiplied")]
        public void WhenTheTwoNumbersAreMultiplied()
        {
            var request = helper.PostRequest(calculator.FirstNumber, calculator.SecondNumber, Calculator.Multiplication);
            dynamic result = helper.Preparation(request, client);
            actualResult = helper.Result(result);
        }


        [When(@"the two numbers are divided")]
        public void WhenTheTwoNumbersAreDivided()
        {
            var request = helper.PostRequest(calculator.FirstNumber, calculator.SecondNumber, Calculator.Division);
            dynamic result = helper.Preparation(request, client);
            actualResult = helper.Result(result);
        }


        [When(@"the number are squared")]
        public void WhenTheNumberAreSquared()
        {
            var request = helper.GetRequest(calculator.Number);
            actualResult = helper.Preparation(request, client);
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResualt)
        {
            Assert.That(actualResult.ToString() == expectedResualt.ToString());
        }


    }
}
