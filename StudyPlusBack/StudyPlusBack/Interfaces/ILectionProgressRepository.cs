using StudyPlusBack.Dtos.LectionProgess;
using StudyPlusBack.Models;

namespace StudyPlusBack.Interfaces
{
    public interface ILectionProgressRepository
    {
        public Task<List<LectionProgress>> getAll();
        public Task<LectionProgress?> getById(int id);
        public Task<LectionProgress> createLP(LectionProgress lectionProgress);
        public Task<LectionProgress> updateLP(int id, UpdateLPDto updateLPDto);
        public Task<LectionProgress> deleteLP(int id);

    }
}
