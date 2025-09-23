using StudyPlusBack.Dtos.Lections;
using StudyPlusBack.Models;
using System.Runtime.CompilerServices;

namespace StudyPlusBack.Mappers
{
    public static class LectionMapper
    {
        public static LectionDto toLectionDto(this Lection lection) 
        {
            return new LectionDto 
            {
                CourseId = lection.CourseId,
                Title = lection.Title,
                Content = lection.Content,
                Lorder = lection.Lorder,
                lectionProgresses = lection.LectionProgresses.Select(l => l.toLectionPDto()).ToList()
            };
        }

        public static Lection fromUserToLection(this createLectionDto createLectionDto, int courseId)
        {
            return new Lection 
            {
                CourseId = courseId,
                Title = createLectionDto.Title,
                Content = createLectionDto.Content,
                Lorder = createLectionDto.Lorder
            };
        }
    }
}
