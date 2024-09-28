using FluentValidation;

namespace Tabr.Application.Entities.Posts.Queries.GetPostDetails
{
    public class GetPostListQueryValidator : AbstractValidator<GetPostDetailsQuery>
    {
        public GetPostListQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty);
            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty);
        }
    }
}