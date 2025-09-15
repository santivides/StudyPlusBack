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
            };
        }

        public static Lection fromUserToLectionDto(this createLectionDto createLectionDto)
        {
            return new Lection 
            {
                CourseId = createLectionDto.CourseId,
                Title = createLectionDto.Title,
                Content = createLectionDto.Content,
                Lorder = createLectionDto.Lorder
            };
        }
    }
}
