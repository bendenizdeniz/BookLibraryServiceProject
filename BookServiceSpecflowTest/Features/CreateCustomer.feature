Feature: Creating Customer

Scenario: Creating a Customer
	Given I have a valid customer creation request with the following data
		| FirstName | LastName | UserName | Password | Address             | Phone        |
		| Ezgi      | Altun    | ezgi     | ezg123   | Sultangazi/Istanbul | 555-456-7890 |
	When I send a POST request to the "https://localhost:7181/api/Customer/CreateCustomer" endpoint with the request body
		"""
		{
		    "FirstName": "Ezgi",
		    "LastName": "Altun",
		    "UserName": "ezgi",
		    "Password": "ezg123",
		    "Address": "Sultangazi/Istanbul",
		    "Phone": "555-456-7890"
		}
		"""
	Then the response status code should be 200 OK
	And the response body should contain a valid customer object
	And the customer object should have a unique identifier
