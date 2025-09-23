using StudyPlusBack.Dtos.Lections;
using StudyPlusBack.Models;

namespace StudyPlusBack.Interfaces
{
    public interface ILectionRepository
    {
        Task<List<Lection>> GetAll();
        Task<Lection?> getById(int id);
        Task<List<LectionDto>> getLectionsByCourse(int id);
        Task<Lection> createLection(Lection lection);
        Task<Lection> updateLection(int id, updateLectionDto updateLectionDto);
        Task<Lection> deleteLection(int id);
        Task<bool> lectionExist(int id);
    }
}
