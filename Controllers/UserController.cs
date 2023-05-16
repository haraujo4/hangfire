using hagnfireJob.Entity;
using hagnfireJob.Entity.DTO;
using hagnfireJob.Interface.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace hagnfireJob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _services;

        public UserController(IUserServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IEnumerable<UserDTO> GetAll()
        {
            return _services.GetUsers();
        }
        [HttpGet("id/{id}")]
        public UserDTO GetById(Guid id)
        {
            return _services.GetUserById(id);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
           var result = await _services.CreateUser(user);
           if(result != null)
                return Ok(result);
           return BadRequest(result);
        }
    }
}
