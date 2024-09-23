using Tabr.Domain.Entities.Blog;

namespace Tabr.Domain.Entities.User
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<BlogPostEntity> Posts { get; set; } = [];
    }
}