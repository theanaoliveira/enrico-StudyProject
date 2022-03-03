using StudyProject.Domain;
using System;

namespace StudyProject.Test.Builders
{
    public class EnderecoBuilder
    {
        public Guid Id;
        public Guid CustomerId;
        public string Cep;
        public string Rua;
        public string Numero;
        public string Complemento;
        public string Bairro;
        public string Cidade;
        public string Estado;


        public static EnderecoBuilder New()
        {
            return new EnderecoBuilder()
            {
                Id = Guid.NewGuid(),
                Cep = "06026000",
                Rua = "Victor Brecheret",
                Numero = "520",
                Complemento = "T8 8D",
                Bairro = "Vila Yara",
                Cidade = "Osasco",
                Estado = "São Paulo",
            };
        }

        public EnderecoBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }
        public EnderecoBuilder WithCep(string cep)
        {
            Cep = cep;
            return this;
        }

        public EnderecoBuilder WithRua(string rua)
        {
            Rua = rua;
            return this;
        }

        public EnderecoBuilder WithNumero(string numero)
        {
            Numero = numero;
            return this;
        }

        public EnderecoBuilder WithComplemento(string complemento)
        {
            Complemento = complemento;
            return this;
        }

        public EnderecoBuilder WithBairro(string bairro)
        {
            Bairro = bairro;
            return this;
        }

        public EnderecoBuilder WithCidade(string cidade)
        {
            Cidade = cidade;
            return this;
        }

        public EnderecoBuilder WithEstado(string estado)
        {
            Estado = estado;
            return this;
        }

        public Endereco Build() => new Endereco(Id, Cep, Rua, Numero, Complemento, Bairro, Cidade, Estado);

    }
}
