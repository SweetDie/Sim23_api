using DAL.Entities.Identity;

namespace BLL.Services.Interfaces
{
    public interface IJwtTokenService
    {
        Task<string> CreateToken(UserEntity user);
    }
}
