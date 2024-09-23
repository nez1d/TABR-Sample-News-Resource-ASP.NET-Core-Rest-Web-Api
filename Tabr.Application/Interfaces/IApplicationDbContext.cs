using Microsoft.EntityFrameworkCore;
using Tabr.Domain.Entities.Blog;
using Tabr.Domain.Entities.User;

namespace Tabr.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<UserEntity> Users { get; set; }
        DbSet<BlogPostEntity> Posts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}