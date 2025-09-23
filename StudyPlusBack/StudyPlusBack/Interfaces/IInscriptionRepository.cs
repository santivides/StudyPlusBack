using StudyPlusBack.Dtos.Inscription;
using StudyPlusBack.Models;

namespace StudyPlusBack.Interfaces
{
    public interface IInscriptionRepository
    {
        public Task<List<Inscription>> getAll();
        public Task<Inscription> getById(int id);
        public Task<Inscription> create(Inscription inscription);
        public Task<Inscription> update(int id, updateInscriptionDto updateInscriptionDto);
        public Task<Inscription> deleteInscription(int id);
        public Task<bool> inscriptionExist(int id);

    }
}
