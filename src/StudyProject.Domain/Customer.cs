using FluentValidation.Results;
using StudyProject.Domain.Validations;
using System;

namespace StudyProject.Domain
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Rg { get; private set; }
        public string Cpf { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public Endereco Endereco { get; private set; }
        public bool Ativo { get; private set; }
        public ValidationResult Validations { get; set; }

        public Customer(Guid id, string fullName, DateTime birthday, string rg, string cpf, DateTime registerDate, Endereco endereco, Boolean ativo)
        {
            Id = id;
            FullName = fullName;
            Birthday = birthday;
            Rg = rg;
            Cpf = cpf;
            RegisterDate = registerDate;
            Endereco = endereco;
            Ativo = ativo;
            Validations = new CustomerValidation().Validate(this);
        }
    }
}
