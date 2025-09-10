using Microsoft.AspNetCore.Mvc;
using StudyPlusBack.Dtos.Courses;
using StudyPlusBack.Mappers;
using StudyPlusBack.Models;

namespace StudyPlusBack.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : Controller
    {

        private readonly StudyPlusContext _context;
        
        public CourseController(StudyPlusContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            var courses = _context.Courses.ToList().Select(s => s.toCourseDto());

            return Ok(courses);
        }

        [HttpGet("{id}")]
        public IActionResult getCourse([FromRoute] int id) 
        {
            var courseModel = _context.Courses.FirstOrDefault(s => s.Id == id);

            if (courseModel == null)
            {
                return NotFound();
            }

            return Ok(courseModel);
        }

        [HttpPost]
        public IActionResult create([FromBody] CreateCourseDto courseDto) 
        {
            if (courseDto == null) 
            {
                return BadRequest();
            }

            var courseModel = courseDto.CreateCourseDto();
            _context.Courses.Add(courseModel);
            _context.SaveChanges();

            return Ok(courseModel);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult update([FromRoute] int id, [FromBody] UpdateCourseDto courseDto) 
        {
            var courseModel = _context.Courses.Find(id);

            if (courseModel == null)
                return NotFound();

            courseModel.Name = courseDto.Name;
            courseModel.Description = courseDto.Description;    
            courseModel.Courselevel = courseDto.Courselevel;
            courseModel.Active = courseDto.Active;
            courseModel.ImgUrl = courseDto.ImgUrl;
            courseModel.Lections = courseDto.Lections;

            _context.SaveChanges();

            return Ok(courseModel);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult delete([FromRoute] int id)
        {
            var courseId = _context.Courses.Find(id);

            if (courseId == null)
                return NotFound();

            _context.Courses.Remove(courseId);
            _context.SaveChanges();

            return NoContent();

        }



    }
}
