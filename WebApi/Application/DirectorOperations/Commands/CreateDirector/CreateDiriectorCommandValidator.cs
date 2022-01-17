using FluentValidation;

namespace WebApi.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(command => command.Model.firstName).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.lastName).NotEmpty().MinimumLength(2);
        }
    }
}