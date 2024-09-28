using FluentValidation;

namespace Tabr.Application.Entities.Posts.Commands.DeletePost
{
    public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
    {
        DeletePostCommandValidator()
        {
            RuleFor(delegePostValidator =>
                delegePostValidator.Id)
                .NotEqual(Guid.Empty);
            RuleFor(deletePostValidator =>
                deletePostValidator.UserId)
                .NotEqual(Guid.Empty);
        }
    }
}