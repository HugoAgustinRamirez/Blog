using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.User;
public record FollowRequest(
    [Required] int FollowedId
);
