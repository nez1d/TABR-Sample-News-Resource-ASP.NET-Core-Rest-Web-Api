using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabr.Domain.Entities.User;

namespace Tabr.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(user => user.Id);

            builder
                .HasIndex(user => user.Login)
                .IsUnique();

            builder
                .HasIndex(user => user.Email)
                .IsUnique();

            builder
                .Property(user => user.Login)
                .HasMaxLength(128)
                .IsRequired();

            builder
                .Property(user => user.Password)
                .HasMaxLength(128)
                .IsRequired();

            builder
                .Property(user => user.Email)
                .HasMaxLength(128)
                .IsRequired();

            builder
                .HasIndex(user => user.Id)
                .IsUnique();

            builder
                .HasMany(user => user.Posts)
                .WithOne(post => post.User);
        }
    }
}