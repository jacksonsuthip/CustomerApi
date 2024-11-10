using Microsoft.AspNetCore.Mvc;
using CustomerApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly PdfService _pdfService;

        public CustomersController(ICustomerRepository customerRepository, PdfService pdfService)
        {
            _customerRepository = customerRepository;
            _pdfService = pdfService;
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
            return Ok(customer);
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
            return NoContent();
        }

        [HttpPost("print")]
        public IActionResult Print([FromBody] List<CustomerMaster> customers)
        {
            try
            {
                var pdfBytes = _pdfService.GenerateCustomerPdf(customers);

                return File(pdfBytes, "application/pdf", "customer_list.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while generating the PDF: {ex.Message}");
            }
        }
    }
}
