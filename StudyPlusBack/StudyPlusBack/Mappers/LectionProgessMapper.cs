using StudyPlusBack.Dtos.LectionProgess;
using StudyPlusBack.Models;

namespace StudyPlusBack.Mappers
{
    public static class LectionProgessMapper
    {
        public static LectionPDto toLectionPDto(this LectionProgress lp)
        {
            return new LectionPDto
            {
                Id = lp.Id,

                InscriptionId = lp.InscriptionId,

                LectionId = lp.LectionId, 

                Completed = lp.Completed,
            };
        }

        public static LectionProgress fromLectionPToLectionPDto(this CreateLPDto lpDto)
        {
            return new LectionProgress
            {
                InscriptionId = lpDto.InscriptionId,

                LectionId = lpDto.LectionId,

                Completed = lpDto.Completed,
            };
        }
    }
}
