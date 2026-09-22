using Models;
using DTO;

namespace Services
{
    
    public interface IUserServices
    {
        Task<string?> Create(CreateUserDto dto);
        Task<string?> Login(LoginUserDto dto);
        Task<bool> Delete(int id);
    }
}

