using Business.Business;
using Entity.Entity;
using Entity.Modals.APIRequestModals;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Infrastructure;

namespace BookServiceSpecflowTest.StepDefinitions
{
    [Binding]
    public sealed class CustomerStepDefinitions
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private CreateCustomerRequestModal _request;
        private Customer _createdCustomer;
        private readonly ISpecFlowOutputHelper _outputHelper;

        public CustomerStepDefinitions(ISpecFlowOutputHelper outputHelper)
        {
            _httpClient = new HttpClient();
            _outputHelper = outputHelper;
        }

        [Given(@"I have a valid customer creation request with the following data")]
        public void GivenIHaveAValidCustomerCreationRequestWithTheFollowingData(Table table)
        {
            _request = table.CreateInstance<CreateCustomerRequestModal>();
        }

        [When(@"I send a POST request to the ""(.*)"" endpoint with the request body")]
        public async Task WhenISendAPOSTRequestToTheEndpointWithTheRequestBody(string endpoint, string requestBody)
        {
            var content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "");
            request.Content = content;

            _response = await _httpClient.SendAsync(request);


            //_response = await _httpClient.PostAsync(endpoint, content);
            _response.EnsureSuccessStatusCode();
            var responseContent = await _response.Content.ReadAsStringAsync();
            _createdCustomer = JsonConvert.DeserializeObject<Customer>(responseContent);

            _outputHelper.WriteLine("Post response is " + responseContent);
        }

        [Then(@"the response status code should be 200 OK")]
        public void ThenTheResponseStatusCodeShouldBeOK()
        {
            //_response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            Assert.True(_response.IsSuccessStatusCode);
        }

        [Then(@"the response body should contain a valid customer object")]
        public void ThenTheResponseBodyShouldContainAValidCustomerObject()
        {
            _createdCustomer.Should().NotBeNull();
            _createdCustomer.Should().BeOfType<Customer>();
        }

        [Then(@"the customer object should have a unique identifier")]
        public void ThenTheCustomerObjectShouldHaveAUniqueIdentifier()
        {
            _createdCustomer.Id.Should().NotBe(0);
        }

        [AfterScenario]
        public void Cleanup()
        {
            _httpClient.Dispose();
        }
    }
}