using Microsoft.AspNetCore.Mvc;
using StudyPlusBack.Dtos.LectionProgess;
using StudyPlusBack.Dtos.Lections;
using StudyPlusBack.Mappers;
using StudyPlusBack.Models;
using System.Reflection.Metadata.Ecma335;

namespace StudyPlusBack.Controllers
{
    [ApiController]
    [Route("api/LectionProgress")]
    public class LectionProgressController : Controller
    {
        public readonly StudyPlusContext _context;

        public LectionProgressController(StudyPlusContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            var LectionProgress = _context.LectionProgresses.Select(lp => lp.toLectionPDto()).ToList();

            return Ok(LectionProgress);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult getById([FromRoute] int id)
        {
            var lectionProgress = _context.LectionProgresses.Find(id);

            if (lectionProgress == null)
                return NotFound();

            return Ok(lectionProgress.toLectionPDto());
        }

        [HttpPost]
        public IActionResult createLP([FromBody] CreateLPDto lp)
        {
            if (lp == null)
            {
                return BadRequest();
            }

            var newLP = lp.fromLectionPToLectionPDto();
            _context.LectionProgresses.Add(newLP);
            _context.SaveChanges();

            return CreatedAtAction(nameof(getById), new { lp = newLP.Id }, newLP.toLectionPDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult updateLp([FromRoute]int id, [FromBody] UpdateLPDto lpDto)
        {
            var lectionP = _context.LectionProgresses.Find(id);

            if (lectionP == null)
                return NotFound();

            lectionP.InscriptionId = lpDto.InscriptionId;
            lectionP.LectionId = lpDto.LectionId;
            lectionP.Completed = lpDto.Completed;

            _context.SaveChanges();

            return Ok(lectionP.toLectionPDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult deleteLectionP([FromRoute] int id)
        {
            var lectionP = _context.LectionProgresses.Find(id);

            if (lectionP == null)
                return NotFound();

            _context.LectionProgresses.Remove(lectionP);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
