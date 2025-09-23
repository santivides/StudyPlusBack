
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudyPlusBack.Dtos.Inscription;
using StudyPlusBack.Interfaces;
using StudyPlusBack.Mappers;
using StudyPlusBack.Models;

namespace StudyPlusBack.Controllers
{

    [Route("api/inscription")]
    [ApiController]
    public class InscriptionController : Controller
    {

        private readonly StudyPlusContext _context;
        private readonly IInscriptionRepository _iInscriptionRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;

        public InscriptionController(StudyPlusContext context, IInscriptionRepository iInscriptionRepository,
            ICourseRepository courseRepository, IUserRepository userRepository)
        {
            _context = context;
            _iInscriptionRepository = iInscriptionRepository;
            _courseRepository = courseRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var inscriptions = await _iInscriptionRepository.getAll();
            var inscriptionDto = inscriptions.Select(i => i.toInscriptionDto());

            return Ok(inscriptionDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> getById([FromRoute] int id) 
        {
            var inscription = await _iInscriptionRepository.getById(id);

            if (inscription == null)
            {
                return NotFound();
            }

            return Ok(inscription.toInscriptionDto());
        }

        [HttpPost("createInsciption/{userId}/{courseId}")]
        public async Task<IActionResult> create([FromRoute]int userId, [FromRoute]int courseId, [FromBody] createInscriptionDto newInscription)
        {
            if(!await _userRepository.userExist(userId))
            {
                Console.WriteLine($"Buscando usuario con Id={userId}");
                return NotFound("user doesnt exist");
            }
                

            if (!await _courseRepository.courseExist(courseId))
                return NotFound("course doesnt exist");

            if (newInscription == null)
            {
                return BadRequest();
            }

            var inscriptions = newInscription.fromUserToCreateDto();
            await _iInscriptionRepository.create(inscriptions);

            return CreatedAtAction(nameof(getById), new{id = inscriptions.Id}, inscriptions.toInscriptionDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateInscription([FromRoute] int id, [FromBody] updateInscriptionDto inscriptionDto) 
        {
            var inscription = await _iInscriptionRepository.update(id, inscriptionDto);

            if (inscription == null)
                return NotFound("inscription doesn't exist");

            return Ok(inscription);
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> deleteInscription([FromRoute] int id) 
        {
            var inscription = await _iInscriptionRepository.deleteInscription(id);

            if (inscription == null)
                return NotFound("Inscription doesn't exist");

            return NoContent();

        }
    }
}
