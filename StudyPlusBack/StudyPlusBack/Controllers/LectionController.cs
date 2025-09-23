using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyPlusBack.Dtos.Lections;
using StudyPlusBack.Interfaces;
using StudyPlusBack.Mappers;
using StudyPlusBack.Models;

namespace StudyPlusBack.Controllers
{
    [Route("api/lection")]
    [ApiController]
    public class LectionController : Controller
    {

        private readonly StudyPlusContext _context;
        private readonly ILectionRepository _lectionRepository;
        private readonly ICourseRepository _courseRepository;

        public LectionController(StudyPlusContext context, ILectionRepository lectionRepository, ICourseRepository courseRepository)
        {
            _context = context;
            _lectionRepository = lectionRepository;
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getAll() 
        {
            var lections = await _lectionRepository.GetAll();
            var lectionsDto = lections.Select(l => l.toLectionDto());

            return Ok(lectionsDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> getById([FromRoute] int id) 
        {
            var lection = await _lectionRepository.getById(id);

            if(lection == null)
            {
                return NotFound();
            }

            return Ok(lection.toLectionDto());
        }

        //get all lections for a specific sourse
        [HttpGet]
        [Route("allLections/{id}")]
        public async Task<IActionResult> getLectionsByCourse([FromRoute] int id)
        {
            //gets al lections from the course and transforms them in the dto
            var lections = await _lectionRepository.getLectionsByCourse(id);

            if (lections == null)
            {
                return NotFound();
            }


            return Ok(lections);
        }

        [HttpPost("{courseId}")]
        public async Task<IActionResult> createLection([FromRoute]int courseId, [FromBody] createLectionDto lectionDto) 
        {
            if (!await _courseRepository.courseExist(courseId))
            {
                return BadRequest("Course does not exist");
            }

            var newLection = lectionDto.fromUserToLection(courseId);
            Console.WriteLine("id:", newLection.Id);
            await _lectionRepository.createLection(newLection);

            return CreatedAtAction(nameof(getById), new{id = newLection.Id}, newLection.toLectionDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateLection([FromRoute] int id, [FromBody] updateLectionDto lectionDto)
        {
            var lection = await _lectionRepository.updateLection(id, lectionDto);

            if (lection == null)
                return BadRequest("lection not found");

            return Ok(lection.toLectionDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> deleteLection([FromRoute] int id) 
        {
            var lection = await _lectionRepository.deleteLection(id);

            if(lection == null)
                return NotFound("Lection does not exist");


            return NoContent();
        }
    }
}
