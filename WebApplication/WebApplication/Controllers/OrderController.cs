using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<Order> GetAll()
        {
            return _orderService.GetAll();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public Order GetById(int id)
        {
            return _orderService.GetById(id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public Order Post(Order order)
        {
            return _orderService.Create(order);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public Order Put(int id, [FromBody] Order value)
        {
            return _orderService.Update(id, value);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
