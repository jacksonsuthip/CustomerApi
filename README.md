
# CustomerApi

## Overview
It provides endpoints for CRUD operations (Create, Read, Update, Delete) as well as a custom endpoint to print the customer list.

## Features
1. **API Development**:
   - Built with .NET Core to serve as the backend for managing customer information.

2. **API Endpoints**:
   - `GET /api/customers` - Retrieves all customers.
   - `POST /api/customers` - Adds a new customer.
   - `PUT /api/customers/{customerCode}` - Updates an existing customer based on the provided `customerCode`.
   - `DELETE /api/customers/{customerCode}` - Deletes a customer specified by `customerCode`.
   - `GET /api/customers/{customerCode}` - Retrieves a single customer by their `customerCode`.
   - `POST /api/customers/print` - Sends a request to print the list of customers.

## Installation and Setup
**Clone the repository**:
   ```bash
   git clone https://github.com/jacksonsuthip/CustomerApi.git
   cd CustomerApi
   ```


## Project Structure
- `Controllers/CustomerController.cs`: Contains the controller for handling customer-related endpoints.
- `Models`: Holds the customer data model.
- `Services`: Includes services for handling print.
- `Repositories`: Contains the repository for database interactions, managing data retrieval and updates.

