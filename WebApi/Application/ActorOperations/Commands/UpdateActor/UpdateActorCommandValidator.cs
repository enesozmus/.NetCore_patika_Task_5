using FluentValidation;

namespace WebApi.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(command => command.Model.firstName).MinimumLength(2).When(x=> x.Model.firstName.Trim() != string.Empty);
            RuleFor(command => command.Model.lastName).MinimumLength(2).When(x=> x.Model.lastName.Trim() != string.Empty);
            RuleFor(command => command.ActorId).GreaterThan(0);
        }
    }
}