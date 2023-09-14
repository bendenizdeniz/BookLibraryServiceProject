Feature: Remove Owner From Book

Scenario: Removing an Owner from a Book
	Given the RemoveOwnerFromBook endpoint is available
	Given I have a valid book ID to remove the owner
	When I send a PUT request to the "https://localhost:7181/api/Book/RemoveOwnerFromBook" endpoint with the book ID 1265025593
	Then response status should be 200 code
	And response body must contain a valid book object
	And the book object should have no owner

