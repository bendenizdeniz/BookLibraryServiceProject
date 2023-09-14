using Entity.Entity;
using Entity.Modals.APIRequestModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICustomerManager
    {
        public Task<Customer> CreateCustomer(CreateCustomerRequestModal createCustomerRequestModal);

        public Task<Customer> GetCustomer(GetCustomerRequestModal customerRequestModal);

        public Task DeleteCustomer(DeleteCustomerRequestModal customerRequestModal);

        public Task<Customer> UpdateCustomer(Customer customer);

        public Task<Customer> Login(LoginRequestModal loginRequestModal);

        public Task<Customer> SaveToken(string token, int customerId);
    }
}
