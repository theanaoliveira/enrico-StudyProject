using System;
using System.Collections.Generic;
using System.Text;

namespace StudyProject.Domain
{
    public class Endereco
    {
        private int cep;
        private string rua;
        private int numero;
        private string complemento;
        private string bairro;
        private string cidade;
        private string estado;

        public int Cep
        {
            get => cep;
            set => cep = value;
        }

        public string Rua
        {
            get => rua;
            set => rua = value;
        }
        public int Numero
        {
            get => numero;
            set => numero = value;
        }

        public string Complemento
        {
            get => complemento;
            set => complemento = value;
        }
        public string Bairro
        {
            get => bairro;
            set => bairro = value;
        }
        public string Cidade
        {
            get => cidade;
            set => cidade = value;
        }
        public string Estado
        {
            get => estado;
            set => estado = value;
        }
    }
}
