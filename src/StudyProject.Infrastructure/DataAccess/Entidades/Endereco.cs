using System;

namespace StudyProject.Infrastructure.DataAccess.Entidades
{
    public class Endereco
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public Guid CustomerId { get; set; }
    }
}
