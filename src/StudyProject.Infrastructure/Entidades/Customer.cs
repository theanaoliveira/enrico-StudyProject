using System;

namespace StudyProject.Infrastructure.Entidades
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime RegisterDate { get; set; }  
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }
    }
}
