using BloodDonationSystem.Application.Commands.InsertDonation;
using FluentValidation;

namespace BloodDonationSystem.Application.Validators;
public class InsertDonationValidator : AbstractValidator<InsertDonationCommand>
{
    public InsertDonationValidator()
    {
        RuleFor(d => d.DonorId)
            .GreaterThan(0)
                .WithMessage("O ID do doador deve ser maior que 0.");

        RuleFor(d => d.AmountMl)
            .InclusiveBetween(420, 470)
                .WithMessage("A quantidade de mililitros de sangue doados deve ser entre 420ml e 470ml.");
    }
}


