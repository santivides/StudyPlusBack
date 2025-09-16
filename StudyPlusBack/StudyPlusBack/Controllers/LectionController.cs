using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyPlusBack.Dtos.Lections;
using StudyPlusBack.Mappers;
using StudyPlusBack.Models;

namespace StudyPlusBack.Controllers
{
    [Route("api/lection")]
    [ApiController]
    public class LectionController : Controller
    {

        private readonly StudyPlusContext _context;

        public LectionController(StudyPlusContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAll() 
        {
            var lections = _context.Lections.Select(l => l.toLectionDto()).ToList();

            return Ok(lections);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult getById([FromRoute] int id) 
        {
            var lection = _context.Lections.FirstOrDefault(l => l.Id == id);

            if(lection == null)
                return NotFound();

            return Ok(lection.toLectionDto());
        }

        //get all lections for a specific sourse
        [HttpGet]
        [Route("allLections/{id}")]
        public IActionResult getLectionsByCourse([FromRoute] int id)
        {
            //gets al lections from the course and transforms them in the dto
            var lections = _context.Lections.
                Where(l => l.CourseId == id).
                Select( l => new LectionDto
                {
                       CourseId = l.CourseId,
                       Title = l.Title,
                       Content = l.Content,
                       Lorder = l.Lorder,
                });

            if (lections == null)
            {
                return NotFound();
            }


            return Ok(lections);
        }

        [HttpPost]
        public IActionResult createLection([FromBody] createLectionDto lectionDto) 
        {
            if (lectionDto == null)
                return BadRequest();

            var newLection = lectionDto.fromUserToLectionDto();
            _context.Lections.Add(newLection);
            _context.SaveChanges();

            return CreatedAtAction(nameof(getById), new{id = newLection.Id}, newLection.toLectionDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult updateLection([FromRoute] int id, [FromBody] updateLectionDto lectionDto)
        {
            var lection = _context.Lections.Find(id);

            if(lection == null)
                return NotFound();

            lection.CourseId = lectionDto.CourseId;
            lection.Title = lectionDto.Title;
            lection.Content = lectionDto.Content;
            lection.Lorder = lectionDto.Lorder;

            _context.SaveChanges();

            return Ok(lection.toLectionDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult deleteLection([FromRoute] int id) 
        {
            var lection = _context.Lections.Find(id);

            if(lection == null)
                return NotFound();

            _context.Lections.Remove(lection);
            _context.SaveChanges(); 

            return NoContent();
        }
    }
}
