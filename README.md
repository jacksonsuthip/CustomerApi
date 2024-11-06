**Customer API**
This repository provides a simple RESTful API for managing customer data, built with .NET Core and Entity Framework. The API allows you to perform CRUD (Create, Read, Update, Delete) operations on customer records in a SQL database.

Features
GET /api/customers - Retrieves a list of all customers.
GET /api/customers/{customerCode} - Retrieves a single customer by customer code.
POST /api/customers - Adds a new customer.
PUT /api/customers/{customerCode} - Updates an existing customer.
DELETE /api/customers/{customerCode} - Deletes a customer.

The API uses standard HTTP status codes for error handling:
200 OK: The request was successful.
201 Created: A new resource was successfully created.
204 No Content: The request was successful, but there is no content to return.
400 Bad Request: The request was invalid, usually due to incorrect or missing data.
404 Not Found: The requested resource was not found.
500 Internal Server Error: An unexpected error occurred on the server.
