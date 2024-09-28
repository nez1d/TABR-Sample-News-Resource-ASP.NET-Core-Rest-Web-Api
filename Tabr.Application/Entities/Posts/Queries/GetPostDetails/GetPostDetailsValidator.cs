using FluentValidation;

namespace Tabr.Application.Entities.Posts.Queries.GetPostDetails
{
    public class GetPostDetailsValidator : AbstractValidator<GetPostDetailsQuery>
    {
        public GetPostDetailsValidator()
        {
            RuleFor(post => post.Id)
                .NotEqual(Guid.Empty);
            RuleFor(post => post.UserId)
                .NotEqual(Guid.Empty);
        }
    }
}
