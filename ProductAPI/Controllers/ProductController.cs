using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Services;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private DBProduct _dbProduct;

        public ProductController()
        {
            _dbProduct = new DBProduct();
        }   
        
        [HttpGet]
        public IActionResult GetProducts(int id)
        {
            // Code to get product from the database
            return Ok(_dbProduct.GetProduct(id));
        }

        [HttpPost]
        public IActionResult AddProduct(string name)
        {
            // Code to add product to the database
            return Ok();
        }
        
        [HttpPut]
        public IActionResult UpdateProduct(int id)
        {
            // Code to update product in the database
            return Ok();
        }

        [HttpDelete]
        public IActionResult RemoveProduct(int id)
        {
            // Code to remove product from the database
            return Ok();
        }

      

    }
}
