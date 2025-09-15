
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudyPlusBack.Dtos.Inscription;
using StudyPlusBack.Mappers;
using StudyPlusBack.Models;

namespace StudyPlusBack.Controllers
{

    [Route("api/inscription")]
    [ApiController]
    public class InscriptionController : Controller
    {

        public readonly StudyPlusContext _context;

        public InscriptionController(StudyPlusContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            var inscriptions = _context.Inscriptions.Select(i => i.toInscriptionDto()).ToList();

            return Ok(inscriptions);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult getById ([FromRoute] int id) 
        {
            var inscription = _context.Inscriptions.Find(id);

            if (inscription == null)
            {
                return NotFound();
            }

            return Ok(inscription.toInscriptionDto());
        }

        [HttpPost]
        public IActionResult create([FromBody] createInscriptionDto newInscription)
        {
            if (newInscription == null)
            {
                return BadRequest();
            }

            var inscriptions = newInscription.fromUserToCreateDto();
            _context.Inscriptions.Add(inscriptions);
            _context.SaveChanges();

            return CreatedAtAction(nameof(getById), new{id = inscriptions.Id}, inscriptions.toInscriptionDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult updateInscription([FromRoute] int id, [FromBody] updateInscriptionDto inscriptionDto) 
        {
            var inscription = _context.Inscriptions.Find(id);

            if (inscription == null)
                return NotFound();

            inscription.UserId = inscriptionDto.UserId;
            inscription.CourseId = inscriptionDto.CourseId;
            inscription.InscriptionDate = inscriptionDto.InscriptionDate;
            inscription.Progress = inscriptionDto.Progress;

            _context.SaveChanges();

            return Ok(inscription);
            
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult deleteInscription([FromRoute] int id) 
        {
            var inscription = _context.Inscriptions.Find(id);

            if (inscription == null)
                return NotFound();

            _context.Inscriptions.Remove(inscription);
            _context.SaveChanges();

            return NoContent();

        }
    }
}
