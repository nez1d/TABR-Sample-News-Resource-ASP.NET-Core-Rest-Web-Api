using Tabr.Domain.Entities.User;

namespace Tabr.Domain.Entities.Blog
{
    public class BlogPostEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public string Details { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatingDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}