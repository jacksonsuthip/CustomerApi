using CustomerApi.Data;
using CustomerApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICustomerRepository
{
    Task<IEnumerable<CustomerMaster>> GetAllCustomers();
    Task<CustomerMaster> GetCustomerByCode(int customerCode);
    Task AddCustomer(CustomerMaster customer);
    Task UpdateCustomer(CustomerMaster customer);
    Task DeleteCustomer(int customerCode);
}
public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerDbContext _context;

    public CustomerRepository(CustomerDbContext context)
    {
        _context = context;
    }

    // Get all customers
    public async Task<IEnumerable<CustomerMaster>> GetAllCustomers()
    {
        return await _context.CustomerMasters.ToListAsync();
    }

    // Get a single customer by CustomerCode
    public async Task<CustomerMaster> GetCustomerByCode(int customerCode)
    {
        return await _context.CustomerMasters.FirstOrDefaultAsync(c => c.CustomerCode == customerCode);
    }

    // Add a new customer
    public async Task AddCustomer(CustomerMaster customer)
    {
        await _context.CustomerMasters.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    // Update an existing customer
    public async Task UpdateCustomer(CustomerMaster customer)
    {
        _context.CustomerMasters.Update(customer);
        await _context.SaveChangesAsync();
    }

    // Delete a customer by CustomerCode
    public async Task DeleteCustomer(int customerCode)
    {
        var customer = await GetCustomerByCode(customerCode);
        if (customer != null)
        {
            _context.CustomerMasters.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
