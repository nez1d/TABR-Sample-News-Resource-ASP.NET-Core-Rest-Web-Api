using FluentValidation;

namespace Tabr.Application.Entities.Posts.Commands.UpdatePost
{
    public class UpdatePostCommndValidatior : AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostCommndValidatior()
        {
            RuleFor(updatePostCommand =>
                updatePostCommand.UserId)
                .NotEqual(Guid.Empty);
            RuleFor(updatePostCommand =>
                updatePostCommand.Id)
                .NotEqual(Guid.Empty);
            RuleFor(updatePostCommand =>
                updatePostCommand.Title)
                .NotEmpty()
                .MaximumLength(250);
        }
    }
}
