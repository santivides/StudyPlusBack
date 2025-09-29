using Microsoft.EntityFrameworkCore;
using StudyPlusBack.Dtos.Courses;
using StudyPlusBack.Helpers;
using StudyPlusBack.Interfaces;
using StudyPlusBack.Models;

namespace StudyPlusBack.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly StudyPlusContext _context;
        public CourseRepository(StudyPlusContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetAll(QueryCourse query)
        {
            var courses = _context.Courses.Include(c => c.Lections).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Name)) 
            {
                courses = courses.Where(s => s.Name.Contains(query.Name));
            }

            courses = courses.Where(s => s.Active.Equals(query.Active));

            var skipPage = (query.PageNumber - 1 ) * query.PageSize;

            return await courses.Skip(skipPage).Take(query.PageSize).ToListAsync();
        }

        public async Task<Course?> getCourse(int id)
        {
            return await _context.Courses.Include(c => c.Lections).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Course> create(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<Course> update(int id, UpdateCourseDto courseDto) 
        {
            var courseModel = await _context.Courses.FindAsync(id);

            if (courseModel == null)
            {
                return null;
            }

            courseModel.Name = courseDto.Name;
            courseModel.Description = courseDto.Description;
            courseModel.Courselevel = courseDto.Courselevel;
            courseModel.Active = courseDto.Active;
            courseModel.ImgUrl = courseDto.ImgUrl;

            await _context.SaveChangesAsync();

            return courseModel;
        }

        public async Task<Course?> delete(int id) 
        {
            var course = await _context.Courses.FindAsync(id);

            if(course == null) 
            {
                return null;
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return course;
        }

        public Task<bool> courseExist(int id)
        {
            return _context.Courses.AnyAsync(c => c.Id == id);
        }
    }
}
