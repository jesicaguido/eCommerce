using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomerAPI.Services;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private DBCustomer _DBCustomer;

        public CustomerController()
        {
            _DBCustomer = new DBCustomer();
        }

        [HttpGet]
        public IActionResult GetCustomers(int id)
        {
            // Code to get Customer from the database
            return Ok(_DBCustomer.GetCustomer(id));
        }

        [HttpPost]
        public IActionResult AddCustomer(string name)
        {
            // Code to add Customer to the database
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCustomer(int id)
        {
            // Code to update Customer in the database
            return Ok();
        }

        [HttpDelete]
        public IActionResult RemoveCustomer(int id)
        {
            // Code to remove Customer from the database
            return Ok();
        }


    }
}
