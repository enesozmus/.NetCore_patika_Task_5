using FluentValidation;

namespace WebApi.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(command => command.Model.firstName).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.lastName).NotEmpty().MinimumLength(2);
        }
    }
}