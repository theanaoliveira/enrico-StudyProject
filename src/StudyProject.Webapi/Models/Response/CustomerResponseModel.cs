using System;

namespace StudyProject.Webapi.Models.Response
{
    public class CustomerResponseModel
    {
        public Guid Id { get; set; }
        public string FullName { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Rg { get; private set; }
        public string Cpf { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public EnderecoResponseModel Endereco { get; private set; }
        public bool Ativo { get; private set; }

        public CustomerResponseModel(Guid id, string fullName, DateTime birthday, string rg, string cpf, DateTime registerDate, EnderecoResponseModel endereco, bool ativo)
        {
            Id = id;
            FullName = fullName;
            Birthday = birthday;
            Rg = rg;
            Cpf = cpf;
            RegisterDate = registerDate;
            Endereco = endereco;
            Ativo = ativo;
        }
    }

    public class EnderecoResponseModel
    {
        public Guid Id { get; private set; }
        public string Cep { get; private set; }
        public string Rua { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public EnderecoResponseModel(Guid id, string cep, string rua, string numero, string complemento, string bairro, string cidade, string estado)
        {
            Id = id;
            Cep = cep;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }
    }
}
