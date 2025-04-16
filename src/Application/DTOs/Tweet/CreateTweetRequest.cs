using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Tweet;
public record CreateTweetRequest(
    [Required][MaxLength(280)] string Content
);
