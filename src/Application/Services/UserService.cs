using Application.DTOs.User;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task AddUserAsync(UserRequest userReq)
    {
        if (string.IsNullOrWhiteSpace(userReq.Username))
            throw new ArgumentException("Username is required.");

        var user = new User()
        {
            Username = userReq.Username,
            Email = userReq.Email,
            CreatedAt = DateTime.UtcNow
        };

        await _userRepository.AddAsync(user);
    }
}
