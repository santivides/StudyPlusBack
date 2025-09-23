using Microsoft.EntityFrameworkCore;
using StudyPlusBack.Dtos.Inscription;
using StudyPlusBack.Interfaces;
using StudyPlusBack.Models;

namespace StudyPlusBack.Repositories
{
    public class InscriptionRepository : IInscriptionRepository
    {
        private readonly StudyPlusContext _context;

        public InscriptionRepository(StudyPlusContext context)
        {
            _context = context;
        }

        public async Task<List<Inscription>> getAll()
        {
            return await _context.Inscriptions.ToListAsync();
        }

        public async Task<Inscription> getById(int id)
        {
            var inscription = await _context.Inscriptions.FindAsync(id);

            if (inscription == null)
                return null;

            return inscription;
        }
        public async Task<Inscription> create(Inscription inscription)
        {
            await _context.Inscriptions.AddAsync(inscription);
            await _context.SaveChangesAsync();

            return inscription;
        }

        public async Task<Inscription> update(int id, updateInscriptionDto inscriptionDto)
        {
            var inscription = await _context.Inscriptions.FindAsync(id);

            if (inscription == null)
                return null;

            inscription.UserId = inscriptionDto.UserId;
            inscription.CourseId = inscriptionDto.CourseId;
            inscription.InscriptionDate = inscriptionDto.InscriptionDate;
            inscription.Progress = inscriptionDto.Progress;

            await _context.SaveChangesAsync();

            return inscription;
        }

        public async Task<Inscription> deleteInscription(int id)
        {
            var inscription = await _context.Inscriptions.FindAsync(id);

            if (inscription == null)
                return null;

            _context.Inscriptions.Remove(inscription);
            await _context.SaveChangesAsync();

            return inscription;
        }

        public Task<bool> inscriptionExist(int id)
        {
            return _context.Inscriptions.AnyAsync(i => i.Id == id);
        }
    }
}
