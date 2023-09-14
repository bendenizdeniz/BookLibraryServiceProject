using Entity.Entity;
using Entity.Modals.APIRequestModals;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BookServiceSpecflowTest.StepDefinitions
{
    [Binding]
    public class RemoveOwnerFromBook
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private RemoveOwnerFromBookRequestModal _request;
        private Book _updatedBook;

        [Given(@"the RemoveOwnerFromBook endpoint is available")]
        public async Task GivenTheRemoveOwnerFromBookEndpointIsAvailable()
        {
            var apiUrl = "https://localhost:7181/api/Book/RemoveOwnerFromBook?BookId=1265025593";
            var content = new StringContent(JsonConvert.SerializeObject(_request), Encoding.UTF8, "application/json");

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJDdXN0b21lcklkIjoiMjU4Njk2MjQ4IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6ImRlbml6Y2NhIiwianRpIjoiNTM0NjI0OGMtMzM5Mi00OWQ5LTlmZDUtYWMzOTBkYzI1YjU5IiwiaWF0IjoiMTQuMDkuMjAyMyAxNzoxODo0NCIsImV4cCI6MTY5NDc0NzkyNCwiaXNzIjoiSldUQXV0aGVudGljYXRpb25TZXJ2ZXIiLCJhdWQiOiJKV1RTZXJ2aWNlQm9va0xpYnJhcnlTZXJ2aWNlQ2xpZW50In0.Kf-kscgknzzEQAhwPN03DF-DBK-SB7bD1_-MF9YgCU4");

                var response = await _httpClient.PutAsync(apiUrl, content);

                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException)
            {
                throw new Exception("API endpoint is not available.");
            }
        }


        [Given(@"I have a valid book ID to remove the owner")]
        public void GivenIHaveAValidBookIDToRemoveTheOwner()
        {
            _request = new RemoveOwnerFromBookRequestModal
            {
                BookId = 1265025593
            };
        }

        [When(@"I send a PUT request to the ""(.*)"" endpoint with the book ID (\d+)")]
        public async Task WhenISendAPUTRequestToTheEndpointWithTheBookID(string endpoint, int bookId)
        {
            var queryParams = $"?BookId={bookId}";
            var content = new StringContent(JsonConvert.SerializeObject(_request), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJDdXN0b21lcklkIjoiMjU4Njk2MjQ4IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6ImRlbml6Y2NhIiwianRpIjoiNTM0NjI0OGMtMzM5Mi00OWQ5LTlmZDUtYWMzOTBkYzI1YjU5IiwiaWF0IjoiMTQuMDkuMjAyMyAxNzoxODo0NCIsImV4cCI6MTY5NDc0NzkyNCwiaXNzIjoiSldUQXV0aGVudGljYXRpb25TZXJ2ZXIiLCJhdWQiOiJKV1RTZXJ2aWNlQm9va0xpYnJhcnlTZXJ2aWNlQ2xpZW50In0.Kf-kscgknzzEQAhwPN03DF-DBK-SB7bD1_-MF9YgCU4");

            _response = await _httpClient.PutAsync(endpoint + queryParams, content);
            _response.EnsureSuccessStatusCode();

            var responseContent = await _response.Content.ReadAsStringAsync();
            _updatedBook = JsonConvert.DeserializeObject<Book>(responseContent);
        }

        [Then(@"response status should be 200 code")]
        public void ThenResponseStatusShouldBe200Code()
        {
            Assert.True(_response.IsSuccessStatusCode);
        }

        [Then(@"response body must contain a valid book object")]
        public void ThenResponseBodyMustContainAValidBookObject()
        {
            _updatedBook.Should().NotBeNull();
            _updatedBook.Should().BeOfType<Book>();
        }

        [Then(@"the book object should have no owner")]
        public void ThenTheBookObjectShouldHaveNoOwner()
        {
            _updatedBook.CustomerId.Should().BeNull();
        }
    }
}
