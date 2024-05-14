using MBBE.Models;

namespace MBBE.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
