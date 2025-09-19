using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyPlusBack.Dtos.Courses;
using StudyPlusBack.Interfaces;
using StudyPlusBack.Mappers;
using StudyPlusBack.Models;
using System.Threading.Tasks;

namespace StudyPlusBack.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : Controller
    {

        private readonly StudyPlusContext _context;
        private readonly ICourseRepository _courseRepository;
        
        public CourseController(StudyPlusContext context, ICourseRepository courseRepository)
        {
            _context = context;
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var courses = await _courseRepository.GetAll();
            var coursesDto = courses.Select(s => s.toCourseDto());

            return Ok(coursesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getCourse([FromRoute] int id) 
        {
            var courseModel = await _courseRepository.getCourse(id);

            if (courseModel == null)
            {
                return NotFound();
            }

            return Ok(courseModel.toCourseDto());
        }
        

        [HttpPost]
        public async Task<IActionResult> create([FromBody] CreateCourseDto courseDto) 
        {
            if (courseDto == null) 
            {
                return BadRequest();
            }

            var courseModel = courseDto.CreateCourseDto();
            await _courseRepository.create(courseModel);

            return CreatedAtAction(nameof(getCourse), new {course = courseModel.Id}, courseModel.toCourseDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> update([FromRoute] int id, [FromBody] UpdateCourseDto courseDto) 
        {
            var courseModel = await _courseRepository.update(id, courseDto);

            if (courseModel == null)
            {
                return BadRequest();
            }

            return Ok(courseModel);

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> delete([FromRoute] int id)
        {
            var courseId = await _courseRepository.delete(id);

            if (courseId == null)
                return NotFound();

            return NoContent();

        }



    }
}
