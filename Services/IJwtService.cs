using Entities.User;
using System.Threading.Tasks;

namespace infrastructure.Services
{
    public interface IJwtService
    {
        Task<AccessToken> GenerateAsync(User user);
    }
}