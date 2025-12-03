using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudyPlusBack.Dtos.Users;
using StudyPlusBack.Helpers;
using StudyPlusBack.Interfaces;
using StudyPlusBack.Mappers;
using StudyPlusBack.Models;

namespace StudyPlusBack.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly StudyPlusContext _context;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(StudyPlusContext context, IUserRepository userRepository,
            UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> singnInManager)
        {
            _context = context;
            _userRepository = userRepository;
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = singnInManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var users = await _userRepository.getAll();
            
            var usersDto = users.Select(s => s.toUserDto());

            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (userDto == null)
            {
                return BadRequest();
            }

            var userModel = userDto.toUserFromCreateDto();
            await _userRepository.create(userModel);

            return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel.toUserDto());
        }

        //IdentityCore user manager create user with jwt
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var appUser = new AppUser
                {
                    UserName = registerDto.Name,
                    Email = registerDto.Email
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if(createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

                    if(roleResult.Succeeded)
                    {
                        return Ok
                            (
                                new newUserDto
                                {
                                    UserName = appUser.UserName,
                                    Email = appUser.Email,
                                    Token = _tokenService.CreateToken(appUser)
                                }
                            );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else 
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e) 
            {
                return Problem(
                    title: "Internal Server Error",
                    detail: e.Message,
                    statusCode: 500
                );
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName);

            if (user == null) return Unauthorized("invalid username");

            //set lockoutOnfailure in false to avoid problems
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("User name not found or password incorrect");

            return Ok
                (
                    new newUserDto
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        Token = _tokenService.CreateToken(user)
                    }
                );
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
