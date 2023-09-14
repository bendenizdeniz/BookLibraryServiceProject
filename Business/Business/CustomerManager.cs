using Business.Interfaces;
using DAL.Interfaces;
using Entity.Entity;
using Entity.Modals.APIRequestModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<Customer> CreateCustomer(CreateCustomerRequestModal createCustomerRequestModal)
        {
            Customer customer = new Customer();

            Guid randomGuid = Guid.NewGuid();
            byte[] bytes = randomGuid.ToByteArray();
            var intId = BitConverter.ToInt32(bytes, 0);

            customer.Id = intId < 0 ? -intId : intId;
            customer.FirstName = createCustomerRequestModal.FirstName;
            customer.LastName = createCustomerRequestModal.LastName;
            customer.UserName = createCustomerRequestModal.UserName;
            customer.Password = createCustomerRequestModal.Password;
            customer.Address = createCustomerRequestModal.Address;
            customer.Phone = createCustomerRequestModal.Phone;
            customer.CreatedTime = DateTime.Now.ToUniversalTime();

            var _customer = await customerRepository.CreateCustomer(customer);
            if (_customer == null)
            {
                throw new InvalidOperationException("Identified Customer has not found.");
            }
            return _customer;
        }

        public async Task DeleteCustomer(DeleteCustomerRequestModal customerRequestModal)
        {
            GetCustomerRequestModal getCustomerRequestModal = new GetCustomerRequestModal();
            getCustomerRequestModal.CustomerId = customerRequestModal.CustomerId;

            Customer customer = await GetCustomer(getCustomerRequestModal);
            await customerRepository.DeleteCustomer(customer);
        }

        public async Task<Customer> GetCustomer(GetCustomerRequestModal customerRequestModal)
        {
            Customer _customer = await customerRepository.GetCustomer(customerRequestModal.CustomerId);
            if (_customer == null)
            {
                throw new InvalidOperationException("Identified Customer has not found.");
            }
            return _customer;
        }

        public async Task<Customer> Login(LoginRequestModal loginRequestModal)
        {
            Customer customer = await customerRepository.GetCustomerByUserName(loginRequestModal.UserName);
            if (customer.Password == loginRequestModal.Password)
            {
                return customer;
            }
            throw new InvalidOperationException("Password Incorrect.");
        }

        public async Task<Customer> SaveToken(string token, int customerId)
        {
            Customer customer = await customerRepository.GetCustomer(customerId);
            
            if (customer == null)
            {
                throw new InvalidOperationException("User not found.");
            }
            
            customer.Token = token;
            return await customerRepository.UpdateCustomer(customer);
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            var existingCustomer = await customerRepository.GetCustomer(customer.Id);

            if (existingCustomer == null)
            {
                throw new InvalidOperationException("Customer has not found.");
            }

            existingCustomer = customer;
            existingCustomer.UpdatedTime = DateTime.Now;

            var updatedCustomer = await customerRepository.UpdateCustomer(existingCustomer);

            if (updatedCustomer == null)
            {
                throw new InvalidOperationException("An Error Occured When A Customre Updated!");
            }

            return existingCustomer;
        }
    }
}
