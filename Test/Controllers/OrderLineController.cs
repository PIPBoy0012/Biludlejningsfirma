using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Model.Repository;
using Test.Model;

namespace Test.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderLineController : ControllerBase
    {
        private readonly IDataRepository<OrderLine> _dataRepository;

        public OrderLineController(IDataRepository<OrderLine> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        //GET: api/OrderLine
        [HttpGet]
        public IActionResult Get()
        {
            var orderLine = _dataRepository.GetAll();
            return Ok(orderLine);
        }

        //GET: api/OrderLine/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var orderLine = _dataRepository.Get(id);

            if (orderLine == null)
            {
                return NotFound("The orderLine was not found");
            }

            return Ok(orderLine);
        }

        //POST: api/OrderLine
        [HttpPost]
        public IActionResult Post([FromBody] OrderLine orderLine)
        {
            if (orderLine == null)
            {
                return BadRequest("The orderLine values were empty");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Add(orderLine);
            return CreatedAtRoute("GetOrder", new { id = orderLine.OrderLines }, null);
        }

        //PUT: api/OrderLine
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] OrderLine orderLine)
        {
            if (orderLine == null)
            {
                return BadRequest("The OrderLine values were empty");
            }

            var orderLineToUpdate = _dataRepository.Get(id);

            if (orderLineToUpdate == null)
            {
                return NotFound("The orderLine was not found");
            }

            _dataRepository.Update(orderLineToUpdate, orderLine);
            return NoContent();
        }

        //DELETE: api/OrderLine
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var orderLine = _dataRepository.Get(id);

            if (orderLine == null)
            {
                return NotFound("The orderLine was not found");
            }

            _dataRepository.Delete(orderLine);
            return NoContent();
        }

    }
}
