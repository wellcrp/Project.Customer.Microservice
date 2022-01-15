using FluentValidation;
using RabbitMQ.Domain;

namespace RabbitMQ.Application.Validators.Customer
{
    public class CustomerPublishValidator : AbstractValidator<CustomerPublish>
    {
        public CustomerPublishValidator()
        {
            RuleFor(p => p.CustomerName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe o nome do cliente");

            RuleFor(p => p.CustomerEmail)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage("Informe o e-mail corretamento do cliente");

            RuleFor(p => p.CustomerAge)
                .NotEmpty()
                .NotNull()
                .InclusiveBetween(1, 200)
                .WithMessage("Idade superior que 1 ano");
        }
    }
}
