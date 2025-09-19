using StudyPlusBack.Dtos.Courses;
using StudyPlusBack.Models;

namespace StudyPlusBack.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAll();
        Task<Course?> getCourse(int id);
        Task<Course> create(Course course);
        Task<Course> update(int id, UpdateCourseDto courseDto);
        Task<Course?> delete(int id);
    }
}
