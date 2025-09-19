using StudyPlusBack.Dtos.Courses;
using StudyPlusBack.Models;
using System.Runtime.CompilerServices;

namespace StudyPlusBack.Mappers
{
    public static class CourseMapper
    {
        public static CourseDto toCourseDto(this Course course) 
        {
            return new CourseDto
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Courselevel = course.Courselevel,
                Active = course.Active,
                ImgUrl = course.ImgUrl,
                Lections = course.Lections.Select(l => l.toLectionDto()).ToList()

            };
        }

        public static Course CreateCourseDto(this BaseCourseDto createCourseDto) 
        {
            return new Course 
            {
                Name = createCourseDto.Name,
                Description = createCourseDto.Description,
                Courselevel = createCourseDto.Courselevel,
                Active = createCourseDto.Active,
                ImgUrl = createCourseDto.ImgUrl,
            };
        }
    }
}
