using StudyProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyProject.Test.Builders
{
    internal class EnderecoBuilder
    {
        private Endereco endereco = new Endereco();
        
        public Endereco GetEndereco()   
        {
            Endereco result = endereco;
            Reset();
            return result;
        }

        public void Reset()
        {
            endereco = new Endereco();
        }

        public void SetBairro(string bairro)
        {
            endereco.Bairro = bairro;
        }

        public void SetCep(int cep)
        {
            endereco.Cep = cep;
        }

        public void SetCidade(string cidade)
        {
            endereco.Cidade = cidade;
        }

        public void SetComplemento(string complemento)
        {
            endereco.Complemento = complemento;
        }

        public void SetEstado(string estado)
        {
            endereco.Estado = estado;
        }

        public void SetNumero(int numero)
        {
            endereco.Numero = numero;
        }

        public void SetRua(string rua)
        {
            endereco.Rua = rua;
        }
    }
}
