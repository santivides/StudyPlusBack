using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyPlusBack.Dtos.Users;
using StudyPlusBack.Interfaces;
using StudyPlusBack.Mappers;
using StudyPlusBack.Models;

namespace StudyPlusBack.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly StudyPlusContext _context;
        private readonly IUserRepository _userRepository;

        public UserController(StudyPlusContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.getAll();
            
            var usersDto = users.Select(s => s.toUserDto());

            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.toUserDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest();
            }

            var userModel = userDto.toUserFromCreateDto();
            await _userRepository.create(userModel);

            return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel.toUserDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserDto userDto)
        {
            var userModel = await _userRepository.update(id, userDto);

            if(userModel == null) 
            {
                return NotFound();
            }

            return Ok(userModel.toUserDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) 
        {
            var userModel = await _userRepository.delete(id);

            if (userModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
