using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyPlusBack.Dtos.Users;
using StudyPlusBack.Mappers;
using StudyPlusBack.Models;

namespace StudyPlusBack.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly StudyPlusContext _context;

        public UserController(StudyPlusContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users.ToList().Select(s => s.toUserDto());

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.toUserDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest();
            }

            var userModel = userDto.toUserFromCreateDto();
            _context.Users.Add(userModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel.toUserDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateUserDto userDto)
        {
            var userModel = _context.Users.Find(id);

            if(userModel == null) 
            {
                return NotFound();
            }

            userModel.Name = userDto.Name;
            userModel.Email = userDto.Email;
            userModel.Password = userDto.Password;
            userModel.Role = userDto.Role;

            _context.SaveChanges();

            return Ok(userModel.toUserDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id) 
        {
            var userModel = _context.Users.Find(id);

            if (userModel == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userModel);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
