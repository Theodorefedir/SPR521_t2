using FluentValidation;
using SPR521_t2.BLL.Dtos.SushiType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR521_t2.BLL.Validators.SushiType
{
    public class CreateSushiTypeValidator : AbstractValidator<CreateSushiTypeDto>
    {
        public CreateSushiTypeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Це поле не може бути пустим")

                .MinimumLength(2).WithMessage("У назві повинно бути мінімум 2 символи")

                .MaximumLength(100).WithMessage("У назві може бути максимум 100 символів");
        }
    }
}
