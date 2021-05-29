using System.Security.Claims;

namespace marketplace.Services.SystemManager.Auth
{
    public interface IJWTService
    {
        ClaimsPrincipal ValidateToken(string jwtToken);
    }
}