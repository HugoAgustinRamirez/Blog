using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
public class TweetConfiguration : IEntityTypeConfiguration<Tweet>
{
    public void Configure(EntityTypeBuilder<Tweet> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Content).IsRequired().HasMaxLength(280);
        builder.Property(t => t.CreatedAt).ValueGeneratedOnAdd();
    }
}