using Microsoft.EntityFrameworkCore;
using Tabr.Application.Interfaces;
using Tabr.Domain.Entities.Blog;
using Tabr.Domain.Entities.User;
using Tabr.Persistence.Configurations;

namespace Tabr.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new BlogPostConfiguration());
            base.OnModelCreating(builder);
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BlogPostEntity> Posts { get; set; }
    }
}