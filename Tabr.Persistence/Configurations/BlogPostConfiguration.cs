using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabr.Domain.Entities.Blog;

namespace Tabr.Persistence.Configurations
{
    public class BlogPostConfiguration
        : IEntityTypeConfiguration<BlogPostEntity>
    {
        public void Configure(EntityTypeBuilder<BlogPostEntity> builder)
        {
            builder.HasKey(post => post.Id);

            builder
                .HasIndex(post => post.Id)
                .IsUnique();

            builder
                .Property(post => post.Title)
                .HasMaxLength(350)
                .IsRequired();

            builder
                .Property(post => post.Text)
                .HasMaxLength(1000)
                .IsRequired();

            builder
                .HasOne(post => post.User)
                .WithMany(user => user.Posts);
        }
    }
}