using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.Data;
using OrderDomain.Models.Entities;


namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderDBContext _dBContext;
        public OrderController(OrderDBContext dBContext) {
            _dBContext = dBContext;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            /*var product= new Product() { Id=1, Name="Product 1", Price=100 };*/
           
            var order= new Order() { CustomerID=1, OrderDate= DateTime.Now, TotalAmount=200 };

            var orderItem1= new OrderItem() { Name="Item 1", Quantity=2, UnitPrice=50, TotalPrice=100 };
            //var orderItem2= new OrderItem() { Name="Item 2", Quantity=1, UnitPrice=100, TotalPrice=100 };

            order.AddOrderItem(orderItem1);
            //order.AddOrderItem(orderItem2);

            //_dBContext.Orders.Add(product);
            _dBContext.Orders.Add(order);

            _dBContext.SaveChanges();

            var result= _dBContext.Orders.ToList();
            return Ok(order);
        }
    }
}
