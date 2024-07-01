using ClientMongoApp.Application.Client.Commands;
using FluentValidation;

namespace ClientMongoApp.Application.Client.Validators
{
    public class CreateClientValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientValidator() 
        {
            RuleFor(x => x.Name).Length(2, 15);
            RuleFor(x => x.Last_name).Length(3, 30);
            RuleFor(x => x.Document_id).NotEmpty().NotNull();
            RuleFor(x => x.Address).NotEmpty().NotNull();
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
