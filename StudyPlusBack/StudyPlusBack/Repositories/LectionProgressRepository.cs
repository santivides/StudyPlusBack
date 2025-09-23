using Microsoft.EntityFrameworkCore;
using StudyPlusBack.Dtos.LectionProgess;
using StudyPlusBack.Interfaces;
using StudyPlusBack.Models;

namespace StudyPlusBack.Repositories
{
    public class LectionProgressRepository : ILectionProgressRepository
    {
        private readonly StudyPlusContext _context;

        public LectionProgressRepository(StudyPlusContext context)
        {
            _context = context;
        }

        public async Task<List<LectionProgress>> getAll()
        {
            var lectionsP = await _context.LectionProgresses.ToListAsync();
            return lectionsP;
        }

        public async Task<LectionProgress?> getById(int id)
        {
            var lectionP = await _context.LectionProgresses.FindAsync(id);

            if(lectionP == null)
                return null;

            return lectionP;
        }

        public async Task<LectionProgress> createLP(LectionProgress lectionProgress)
        {
            await _context.LectionProgresses.AddAsync(lectionProgress);
            await _context.SaveChangesAsync();

            return lectionProgress;
        }

        public async Task<LectionProgress> updateLP(int id, UpdateLPDto lpDto)
        {
            var lectionP = await _context.LectionProgresses.FindAsync(id);

            if (lectionP == null)
                return null;

            lectionP.InscriptionId = lpDto.InscriptionId;
            lectionP.LectionId = lpDto.LectionId;
            lectionP.Completed = lpDto.Completed;

            await _context.SaveChangesAsync();

            return lectionP;
        }

        public async Task<LectionProgress> deleteLP(int id)
        {
            var lectionP = await _context.LectionProgresses.FindAsync(id);

            if (lectionP == null)
                return null;

            _context.LectionProgresses.Remove(lectionP);
            await _context.SaveChangesAsync();

            return lectionP;
        }
    }
}
