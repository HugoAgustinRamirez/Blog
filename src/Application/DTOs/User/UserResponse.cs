namespace Application.DTOs.User;
public record UserResponse(
    int Id,
    string Username,
    string Email,
    DateTime CreatedAt
);
