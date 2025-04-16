using Application.DTOs.User;

namespace Application.Interfaces;

public interface IUserService
{
    Task AddUserAsync(UserRequest user);
}
