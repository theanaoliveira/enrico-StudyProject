using StudyProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyProject.Application.UseCases.Add
{
    public class AddRequest
    {
        public string FullName { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Rg { get; private set; }
        public string Cpf { get; private set; }
        public string Cep { get; private set; }
        public string Rua { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public Endereco Endereco { get; set; }
        public Customer Customer { get; set; }
        public List<string> Erros { get; set; }

        public AddRequest(string fullName, DateTime birthday, string rg, string cpf, string cep, string rua, string numero, string complemento, string bairro, string cidade, string estado)
        {
            FullName = fullName;
            Birthday = birthday;
            Rg = rg;
            Cpf = cpf;
            Cep = cep;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Erros = new List<string>();
        }

    }
}