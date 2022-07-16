using Az204.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Az204.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet("GetAllAsync")]
        public IActionResult GetAllAsync()
        {
            var customers = customerRepository.GetAllAsync().Result;
            return Ok(customers);
        }

        [HttpGet("GetByIdAsync/{id}")]
        public IActionResult GetByIdAsync(int id)
        {
            var customer = customerRepository.GetByIdAsync(id).Result;
            return Ok(customer);
        }
    }
}
