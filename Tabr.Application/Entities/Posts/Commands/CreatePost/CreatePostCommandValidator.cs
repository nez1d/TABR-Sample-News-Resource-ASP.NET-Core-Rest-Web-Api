using FluentValidation;

namespace Tabr.Application.Entities.Posts.Commands.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(createPostCommand =>
                createPostCommand.Title)
                .NotEmpty()
                .MaximumLength(250);
            RuleFor(createPostCommand =>
                createPostCommand.UserId)
                .NotEqual(Guid.Empty);
        }
    }
}