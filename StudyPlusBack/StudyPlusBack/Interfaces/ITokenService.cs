using StudyPlusBack.Models;

namespace StudyPlusBack.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
