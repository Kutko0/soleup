using Soleup.API.DTOs;

namespace Soleup.API.Auth
{
    public interface ITokenService
    {
        string BuildToken(UserDTO user);
        bool IsTokenValid(string token);
    }
}