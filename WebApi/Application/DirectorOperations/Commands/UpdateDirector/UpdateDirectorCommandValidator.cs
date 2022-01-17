using FluentValidation;

namespace WebApi.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(command => command.Model.firstName).MinimumLength(2).When(x=> x.Model.firstName.Trim() != string.Empty);
            RuleFor(command => command.Model.lastName).MinimumLength(2).When(x=> x.Model.lastName.Trim() != string.Empty);
            RuleFor(command => command.DirectorId).GreaterThan(0);
        }
    }
}