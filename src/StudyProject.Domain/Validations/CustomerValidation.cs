using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyProject.Domain.Validations
{
    public class CustomerValidation: AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(r => r.Id).NotEqual(new Guid()); //00000000-0000-0000-0000-000000000000
            RuleFor(r => r.FullName).NotEmpty().NotNull().WithMessage("Nome completo não pode ser em branco");
            RuleFor(r => r.Birthday).NotNull().GreaterThan(DateTime.MinValue).LessThan(DateTime.MaxValue).WithMessage("Data de nascimento não pode ser em branco");
            RuleFor(r => r.Rg).NotEmpty().NotNull().MinimumLength(12).MaximumLength(12).WithMessage("Rg deve ter exatamente 12 digitos");
            RuleFor(r => r.Cpf).NotEmpty().NotNull().MinimumLength(14).MaximumLength(14).WithMessage("Cpf deve ter exatamente 14 digitos");
            RuleFor(r => r.RegisterDate).NotEmpty().NotNull().GreaterThanOrEqualTo(DateTime.MinValue).LessThanOrEqualTo(DateTime.MaxValue).WithMessage("Data de cadastro não pode ser em branco");
            RuleFor(r => r.Endereco).NotNull().WithMessage("Endereco não pode ser em branco");
            RuleFor(r => r.Ativo).NotEmpty().NotNull().WithMessage("Cliente deve estar ativo");
        }
    }
}
