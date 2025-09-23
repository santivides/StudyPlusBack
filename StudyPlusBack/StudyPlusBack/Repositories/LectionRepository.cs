using Microsoft.EntityFrameworkCore;
using StudyPlusBack.Dtos.LectionProgess;
using StudyPlusBack.Dtos.Lections;
using StudyPlusBack.Interfaces;
using StudyPlusBack.Mappers;
using StudyPlusBack.Models;

namespace StudyPlusBack.Repositories
{
    public class LectionRepository : ILectionRepository
    {
        private readonly StudyPlusContext _context;

        public LectionRepository(StudyPlusContext context)
        {
            _context = context;
        }

        public async Task<List<Lection>> GetAll()
        {
            var lections = await _context.Lections.Include(l => l.LectionProgresses).ToListAsync();

            return lections;
        }

        public async Task<Lection?> getById(int id)
        {
            var lections = await _context.Lections.Include(l => l.LectionProgresses).FirstOrDefaultAsync(l => l.Id == id);

            if (lections == null) 
            {
                return null;
            }

            return lections;
        }

        public async Task<List<LectionDto>> getLectionsByCourse(int id)
        {
            var lections = await _context.Lections.
                Where(l => l.CourseId == id).
                Select(l => new LectionDto
                {
                    CourseId = l.CourseId,
                    Title = l.Title,
                    Content = l.Content,
                    Lorder = l.Lorder,
                }).ToListAsync();

            return lections;
        }

        public async Task<Lection> createLection(Lection lection)
        {
            await _context.Lections.AddAsync(lection);
            await _context.SaveChangesAsync();

            return lection;
        }

        public async Task<Lection> updateLection(int id, updateLectionDto lectionDto)
        {
            var lection = await _context.Lections.FindAsync(id);

            if (lection == null)
                return null;

            lection.Title = lectionDto.Title;
            lection.Content = lectionDto.Content;
            lection.Lorder = lectionDto.Lorder;

            await _context.SaveChangesAsync();

            return lection;
        }

        public async Task<Lection> deleteLection(int id)
        {
            var lection = await  _context.Lections.FindAsync(id);

            if (lection == null)
                return null;

            _context.Lections.Remove(lection);
            await _context.SaveChangesAsync();

            return lection;
        }

        public Task<bool> lectionExist(int id)
        {
            return _context.Lections.AnyAsync(l => l.Id == id);
        }
    }
}
