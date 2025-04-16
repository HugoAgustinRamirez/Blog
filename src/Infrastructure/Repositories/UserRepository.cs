using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User?> GetByIdAsync(int id)
        => await context.Users.FirstOrDefaultAsync(u => u.Id == id);

    public async Task<bool> ExistsAsync(int userId)
        => await context.Users.AnyAsync(u => u.Id == userId);
    public async Task AddAsync(User user)
        => await context.Users.AddAsync(user);
}