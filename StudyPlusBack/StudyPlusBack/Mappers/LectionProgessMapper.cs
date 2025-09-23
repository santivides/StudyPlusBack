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

                InscriptionId = lp.InscriptionId,

                LectionId = lp.LectionId, 

                Completed = lp.Completed,
            };
        }

        public static LectionProgress fromLectionPToLectionPDto(this CreateLPDto lpDto, int lectionId, int inscriptionId)
        {
            return new LectionProgress
            {
                InscriptionId = inscriptionId,

                LectionId = lectionId,

                Completed = lpDto.Completed,
            };
        }
    }
}
