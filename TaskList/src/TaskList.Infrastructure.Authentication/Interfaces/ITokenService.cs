

using TaskList.Domain.Entities;

namespace TaskList.Infrastructure.Authentication.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Usuario user);
    }
}