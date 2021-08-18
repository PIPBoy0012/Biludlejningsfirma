using System;
using Microsoft.AspNetCore.Mvc;
using Test.Model.Repository;
using Test.Model;
using System.Linq;
using System.Collections.Generic;

namespace Test.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class OrderController : ControllerBase
    {
        private readonly IDataRepository<Order> _dataRepository;

        public OrderController(IDataRepository<Order> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        //GET: api/Order
        [HttpGet]
        public IActionResult Get()
        {
            var orders = _dataRepository.GetAll();

            return Ok(orders);
        }
        
        //GET: api/Order/1
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var order = _dataRepository.Get(id);
            if (order == null)
            {
                return NotFound("order not found");
            }
            return Ok(order);
        }

        //POST: api/Order
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("The order values were null");
            }

            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }

            _dataRepository.Add(order);
            return CreatedAtRoute("GetProdukt", new { id = order.OrderId }, null);
        }

        //PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("The order values were null");
            }
            var orderToUpdate = _dataRepository.Get(id);
            if (orderToUpdate == null)
            {
                return NotFound("The order was not found");
            }

            _dataRepository.Update(orderToUpdate, order);
            return NoContent();
        }

        //DELETE: api/Order/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = _dataRepository.Get(id);
            if (order == null)
            {
                return NotFound("The order was not found");
            }

            _dataRepository.Delete(order);
            return NoContent();
        }
    }

}
