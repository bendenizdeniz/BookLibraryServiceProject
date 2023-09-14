Feature: Get Book By Name

Scenario: Getting a Book by Name
	Given the GetBookByName endpoint is available
	And I have a valid book name to search for
	When I send a GET request to the "https://localhost:7181/api/Book/GetBookByName" endpoint with the book name "Sefiller"
	Then the response status code should be 200
	And the response body should contain a valid book object
	And the book object should have the following properties
		| Name     | Author      | Category         |
		| Sefiller | Victor Hugo | Dunya Klasikleri |


