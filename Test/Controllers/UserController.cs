using System;
using Test.Model.Repository;
using Microsoft.EntityFrameworkCore;
using Test.Model;
using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDataRepository<User> _dataRepository;

        public UserController(IDataRepository<User> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        //GET: api/Users
        [HttpGet]
        public IActionResult Get()
        {
            var users = _dataRepository.GetAll();
            return Ok(users);
        }

        //GET: api/Users/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(long id)
        {
            var user = _dataRepository.Get(id);

            if (user == null)
            {
                return NotFound("The user was not found");
            }

            return Ok(user);
        }

        //POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("The user values were null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Add(user);

            //return CreatedAtRoute("GetUser", new { id = user.UserId }, null);
            return Ok("The user has been created");
        }

        //PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("The user valus were null");
            }
            var userToUpdate = _dataRepository.Get(id);
            if (userToUpdate == null)
            {
                return NotFound("The user was not found");
            }
            _dataRepository.Update(userToUpdate, user);
            return Ok("User updated");
            //return NoContent();
        }

        //DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _dataRepository.Get(id);

            if (user == null)
            {
                return NotFound("The user was not found");
            }

            _dataRepository.Delete(user);
            return Ok("User deleted");
            //return NoContent();
        }
    }
}
