using BookLibraryAPI.Models.APIRequestModels;
using Business.Interfaces;
using Entity.Entity;
using Entity.Modals.APIRequestModals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookLibraryAPI.JwtSecurity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BookLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager customerManager;
        private readonly JwtConfiguration jwtConfiguration;

        public CustomerController(ICustomerManager customerManager, JwtConfiguration jwtConfiguration)
        {
            this.customerManager = customerManager;
            this.jwtConfiguration = jwtConfiguration;
        }

        [HttpGet("GetCustomer")]
        public async Task<Customer> GetCustomer([FromQuery] GetCustomerRequestModal customerRequest)
        {
            return await customerManager.GetCustomer(customerRequest);
        }

        [HttpPost("CreateCustomer")]
        public async Task<Customer> CreateCustomer(CreateCustomerRequestModal customerRequestModal)
        {
            return await customerManager.CreateCustomer(customerRequestModal);
        }

        //[AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginRequestModal loginRequestModal)
        {

            Customer customer = await customerManager.Login(loginRequestModal);

            if (customer == null)
                return BadRequest("Password Incorrect.");
            else
            {
                var token = jwtConfiguration.GenerateToken(customer);

                if (token is not null)
                {
                    return Ok(await customerManager.SaveToken(token, customer.Id));
                }
                return BadRequest("Token is Unavailable.");
            }
        }

        [HttpDelete("DeleteCustomer")]
        public async Task DeleteCustomer([FromQuery] DeleteCustomerRequestModal customerRequestModal)
        {
            await customerManager.DeleteCustomer(customerRequestModal);
        }
    }
}
