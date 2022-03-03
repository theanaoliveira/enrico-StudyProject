using FluentValidation;
using System;

namespace StudyProject.Domain.Validations
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {    
        public EnderecoValidation()
        {
            RuleFor(r => r.Id).NotEqual(new Guid()); //00000000-0000-0000-0000-000000000000
            RuleFor(r => r.Cep).NotEmpty().NotNull().MinimumLength(8).MaximumLength(8).WithMessage("Cep não pode ser em branco e deve ter 8 caracteres");
            RuleFor(r => r.Rua).NotEmpty().NotNull().WithMessage("Rua não pode ser em branco");
            RuleFor(r => r.Numero).NotEmpty().NotNull().WithMessage("Numero não pode ser em branco");
            RuleFor(r => r.Bairro).NotEmpty().NotNull().WithMessage("Bairro não pode ser em branco");
            RuleFor(r => r.Cidade).NotEmpty().NotNull().WithMessage("Cidade não pode ser em branco");
            RuleFor(r => r.Estado).NotEmpty().NotNull().WithMessage("Estado não pode ser em branco");
        }    
    }
}
