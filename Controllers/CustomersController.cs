using Microsoft.AspNetCore.Mvc;
using CustomerApi.Models.Entities;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/customers
        /// <summary>
        /// Retrieves all customers
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomers();
            return Ok(customers);
        }

        // GET: api/customers/{customerCode}
        /// <summary>
        /// Retrieves a customer by their unique customer code
        /// </summary>
        /// <param name="customerCode">The unique identifier for the customer</param>
        [HttpGet("{customerCode}")]
        public async Task<IActionResult> GetCustomerByCode(int customerCode)
        {
            var customer = await _customerRepository.GetCustomerByCode(customerCode);
            if (customer == null)
            {
                return NotFound($"Customer with code {customerCode} not found.");
            }
            return Ok(customer);
        }

        // POST: api/customers
        /// <summary>
        /// Adds a new customer
        /// </summary>
        /// <param name="customer">The customer data to be added</param>
        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerMaster customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer data is required.");
            }
            await _customerRepository.AddCustomer(customer);

            // Define the route values as an anonymous object
            var routeValues = new { customerCode = customer.CustomerCode };

            // Return the CreatedAtAction with route values and response data
            return CreatedAtAction(nameof(GetCustomerByCode), routeValues, customer);
        }

        // PUT: api/customers/{customerCode}
        /// <summary>
        /// Updates an existing customer by their customer code
        /// </summary>
        /// <param name="customerCode">The unique identifier for the customer</param>
        /// <param name="customer">The customer data to be updated</param>
        [HttpPut("{customerCode}")]
        public async Task<IActionResult> UpdateCustomer(int customerCode, [FromBody] CustomerMaster customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer data is required.");
            }
            customer.CustomerCode = customerCode;
            await _customerRepository.UpdateCustomer(customer);
            return Ok(customer);  // Return updated customer
        }

        // DELETE: api/customers/{customerCode}
        /// <summary>
        /// Deletes a customer by their unique customer code
        /// </summary>
        /// <param name="customerCode">The unique identifier for the customer</param>
        [HttpDelete("{customerCode}")]
        public async Task<IActionResult> DeleteCustomer(int customerCode)
        {
            await _customerRepository.DeleteCustomer(customerCode);
            return NoContent();  // No content on successful deletion
        }
    }
}
