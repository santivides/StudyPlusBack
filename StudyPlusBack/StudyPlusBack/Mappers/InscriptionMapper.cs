using StudyPlusBack.Dtos.Inscription;
using StudyPlusBack.Models;

namespace StudyPlusBack.Mappers
{
    public static class InscriptionMapper
    {
        public static InscriptionDto toInscriptionDto(this Inscription inscription)
        {
            return new InscriptionDto 
            {
                UserId = inscription.UserId,
                CourseId = inscription.CourseId,
                InscriptionDate = inscription.InscriptionDate,
                Progress = inscription.Progress
            };
        }

        public static Inscription fromUserToCreateDto(this createInscriptionDto inscriptionDto)
        {
            return new Inscription 
            {
                UserId = inscriptionDto.UserId,
                CourseId = inscriptionDto.CourseId,
                InscriptionDate = inscriptionDto.InscriptionDate,
                Progress = inscriptionDto.Progress
            };
        }

    }
}
