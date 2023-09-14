using Entity.Entity;
using Entity.Modals.APIRequestModals;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace BookServiceSpecflowTest.StepDefinitions
{
    [Binding]
    public class GetBookByName
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private GetBookByNameRequestModal _request;
        private Book _retrievedBook;

        [Given(@"the GetBookByName endpoint is available")]
        public async Task GivenTheGetBookByNameEndpointIsAvailable()
        {
            var apiUrl = "https://localhost:7181/api/Book/GetBookByName?BookName=Sefiller";
            var content = new StringContent(JsonConvert.SerializeObject(_request), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJDdXN0b21lcklkIjoiMjU4Njk2MjQ4IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6ImRlbml6Y2NhIiwianRpIjoiZjRjMzg3YzgtMzcwYi00NDI1LTlkOTktYjQwZDg5Zjg2OTU5IiwiaWF0IjoiMTQuMDkuMjAyMyAxNTowNjoyOCIsImV4cCI6MTY5NDczOTk4OCwiaXNzIjoiSldUQXV0aGVudGljYXRpb25TZXJ2ZXIiLCJhdWQiOiJKV1RTZXJ2aWNlQm9va0xpYnJhcnlTZXJ2aWNlQ2xpZW50In0.FQaB2lpPkwdCFbLrwdAQA4tRfg0GcZDeGMs97rD6IQc");
                    request.Content = content;

                    var response = await _httpClient.SendAsync(request);

                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException)
                {
                    throw new Exception("API endpoint is not available.");
                }
            }
        }

        [Given(@"I have a valid book name to search for")]
        public void GivenIHaveAValidBookNameToSearchFor()
        {
            _request = new GetBookByNameRequestModal
            {
                BookName = "Sefiller"
            };
        }

        [When(@"I send a GET request to the ""(.*)"" endpoint with the book name ""(.*)""")]
        public async Task WhenISendAGETRequestToTheEndpointWithTheBookName(string endpoint, string bookName)
        {
            _request.BookName = bookName;
            var queryParams = $"?BookName={bookName}";
            var currentEndpoint = endpoint + queryParams;

            var content = new StringContent(JsonConvert.SerializeObject(_request), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Get, currentEndpoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJDdXN0b21lcklkIjoiMjU4Njk2MjQ4IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6ImRlbml6Y2NhIiwianRpIjoiZjRjMzg3YzgtMzcwYi00NDI1LTlkOTktYjQwZDg5Zjg2OTU5IiwiaWF0IjoiMTQuMDkuMjAyMyAxNTowNjoyOCIsImV4cCI6MTY5NDczOTk4OCwiaXNzIjoiSldUQXV0aGVudGljYXRpb25TZXJ2ZXIiLCJhdWQiOiJKV1RTZXJ2aWNlQm9va0xpYnJhcnlTZXJ2aWNlQ2xpZW50In0.FQaB2lpPkwdCFbLrwdAQA4tRfg0GcZDeGMs97rD6IQc");
            request.Content = content;

            _response = await _httpClient.SendAsync(request);

            _response.EnsureSuccessStatusCode();

            var responseContent = await _response.Content.ReadAsStringAsync();
            _retrievedBook = JsonConvert.DeserializeObject<Book>(responseContent);
        }

        [Then(@"the response status code should be 200")]
        public void ThenTheResponseStatusCodeShouldBeOK()
        {
            Assert.True(_response.IsSuccessStatusCode);
        }

        [Then(@"the response body should contain a valid book object")]
        public void ThenTheResponseBodyShouldContainAValidBookObject()
        {
            _retrievedBook.Should().NotBeNull();
            _retrievedBook.Should().BeOfType<Book>();
        }

        [Then(@"the book object should have the following properties")]
        public void ThenTheBookObjectShouldHaveTheFollowingProperties(Table table)
        {
            var expectedBook = table.CreateInstance<Book>();

            _retrievedBook.Name.Should().Be(expectedBook.Name);
            _retrievedBook.Author.Should().Be(expectedBook.Author);
            _retrievedBook.Category.Should().Be(expectedBook.Category);
        }
    }
}

