using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<Customer> CreateCustomer(Customer customer);

        public Task<Customer> GetCustomer(int id);

        public Task DeleteCustomer(Customer customer);

        public Task<Customer> UpdateCustomer(Customer customer);

        public Task<Customer> GetCustomerByUserName(string userName);
    }
}
