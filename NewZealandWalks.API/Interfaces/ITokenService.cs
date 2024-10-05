using Microsoft.AspNetCore.Identity;

namespace NewZealandWalks.API.Interfaces
{
    public interface ITokenService
    {
      string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
