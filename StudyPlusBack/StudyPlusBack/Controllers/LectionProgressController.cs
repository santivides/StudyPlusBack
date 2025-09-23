using Microsoft.AspNetCore.Mvc;
using StudyPlusBack.Dtos.LectionProgess;
using StudyPlusBack.Dtos.Lections;
using StudyPlusBack.Interfaces;
using StudyPlusBack.Mappers;
using StudyPlusBack.Models;
using System.Reflection.Metadata.Ecma335;

namespace StudyPlusBack.Controllers
{
    [ApiController]
    [Route("api/LectionProgress")]
    public class LectionProgressController : Controller
    {
        private readonly StudyPlusContext _context;
        private readonly ILectionProgressRepository _ILectionProgressRepository;
        private readonly ILectionRepository _ILectionRepository;
        private readonly IInscriptionRepository _InscriptionRepository;


        public LectionProgressController(StudyPlusContext context, ILectionProgressRepository ILectionProgressRepository,
            ILectionRepository iLectionRepository, IInscriptionRepository InscriptionRepository)
        {
            _context = context;
            _ILectionProgressRepository = ILectionProgressRepository;
            _ILectionRepository = iLectionRepository;
            _InscriptionRepository = InscriptionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var LectionProgress = await _ILectionProgressRepository.getAll();
            var LPDto = LectionProgress.Select(lp => lp.toLectionPDto());

            return Ok(LPDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> getById([FromRoute] int id)
        {
            var lectionProgress = await _ILectionProgressRepository.getById(id);

            if (lectionProgress == null)
                return NotFound();

            return Ok(lectionProgress.toLectionPDto());
        }

        [HttpPost("createLp/{lectionId}/{inscriptionId}")]
        public async Task<IActionResult> createLP([FromRoute]int lectionId, [FromRoute] int inscriptionId, [FromBody] CreateLPDto lp)
        {
            if (!await _ILectionRepository.lectionExist(lectionId))
                return NotFound("lection does not exist");

            if(!await _InscriptionRepository.inscriptionExist(inscriptionId))
                return NotFound("inscription does not exist");

            if (lp == null)
            {
                return BadRequest();
            }

            var newLP = lp.fromLectionPToLectionPDto(lectionId, inscriptionId);
            await _ILectionProgressRepository.createLP(newLP);

            return CreatedAtAction(nameof(getById), new { lp = newLP.Id }, newLP.toLectionPDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateLp([FromRoute]int id, [FromBody] UpdateLPDto lpDto)
        {
            var lectionP = await _ILectionProgressRepository.updateLP(id, lpDto);

            return Ok(lectionP.toLectionPDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> deleteLectionP([FromRoute] int id)
        {
            var lectionP = await _ILectionProgressRepository.deleteLP(id);

            if (lectionP == null)
                return NotFound("Lection progress does not exist");

            return NoContent();
        }
    }
}
