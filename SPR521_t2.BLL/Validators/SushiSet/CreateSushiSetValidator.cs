namespace SPR521_t2.BLL.Dtos.SushiSet;

using FluentValidation;
using SPR521_t2.BLL.Dtos.SushiSet;

public class CreateSushiSetValidator : AbstractValidator<CreateSushiSetDto>
{
    public CreateSushiSetValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");

        RuleFor(x => x.Weight)
            .GreaterThan(0).WithMessage("Weight must be greater than 0.");

        RuleFor(x => x.SushiTypeId)
            .GreaterThan(0).WithMessage("Valid SushiTypeId is required.");
    }
}