using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplnventory.Models;
using WebApplnventory.Repository;

namespace WebApplnventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public UserController(IUserRepository user)
        {
            _User = user;
        }

        public IUserRepository _User { get; set; }

        [HttpPost]
        public void Post([FromBody] MUsers modal)
        {
            _User.Create(modal);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _User.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpGet]
        public List<MUsers> Get()
        {
            return _User.GetAll();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MUsers modal)
        {
            _User.Update(id, modal);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _User.Delete(id);
        }
    }
}