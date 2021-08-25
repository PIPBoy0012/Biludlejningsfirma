using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Model.Repository;
using Test.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class ProdukterController : ControllerBase
    {
        //private readonly IDataRepository<Produkter> _dataRepository;
        private readonly IProdukterRepository<Produkter> _produkterRepository;

        public ProdukterController(IProdukterRepository<Produkter> produkterRepository)
        {
            _produkterRepository = produkterRepository;
        }

        //GET: api/Produkter
        [HttpGet]
        public IActionResult Get()
        {
            var produkter = _produkterRepository.GetAll();
            return Ok(produkter);
        }


        //GET: api/Produkter/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var produkt = _produkterRepository.Get(id);

            if (produkt == null)
            {
                return NotFound("The produkt was not found");
            }

            return Ok(produkt);
        }

        //GET: api/Produkter/bil
        //[HttpGet("{type}")]
        [HttpGet]
        [Route("get/{type}")]
        public IActionResult GetType(string type)
        {
            var produkt = _produkterRepository.GetType(type);

            if (produkt == null)

            {
                return NotFound("The produkt was not found");
            }

            return Ok(produkt);
        }

        //POST: api/Produkter
        [HttpPost]
        public IActionResult Post([FromBody] Produkter produkt)
        {
            if (produkt == null)
            {
                return BadRequest("The produkt values were empty");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _produkterRepository.Add(produkt);
            return CreatedAtRoute("GetProdukt", new { id = produkt.ProduktId }, null);
        }

        //PUT: api/Produkter/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Produkter produkt)
        {
            if (produkt == null)
            {
                return BadRequest("The produkt values were null");
            }
            var produktToUpdate = _produkterRepository.Get(id);
            if (produktToUpdate == null)
            {
                return NotFound("The produkt was not found");
            }

            _produkterRepository.Update(produktToUpdate, produkt);
            return NoContent();
        }

        //DELETE: api/Produkter/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produkt = _produkterRepository.Get(id);

            if (produkt == null)
            {
                return NotFound("The produkt was not found");
            }

            _produkterRepository.Delete(produkt);
            return NoContent();
        }
    }
}
