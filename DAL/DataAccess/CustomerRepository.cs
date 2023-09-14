using DAL.Interfaces;
using Entity.Context;
using Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataAccess
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BookLibraryContext context;

        public CustomerRepository(BookLibraryContext _context)
        {
            this.context = _context;
        }
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            await context.Customers.AddAsync(customer);
            context.SaveChanges();
            return customer;
        }

        public async Task DeleteCustomer(Customer customer)
        {
            context.Customers.Remove(customer);
            await context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            Customer customer = await context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
            {
                throw new InvalidOperationException("Identified LibraryCenter has not found.");
            }
            return customer;
        }

        public async Task<Customer> GetCustomerByUserName(string userName)
        {
            Customer customer = await context.Customers.FirstOrDefaultAsync(c => c.UserName == userName);
            if (customer == null)
            {
                throw new InvalidOperationException("Identified LibraryCenter has not found.");
            }
            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            context.Customers.Update(customer);
            await context.SaveChangesAsync();
            return customer;
        }
    }
}