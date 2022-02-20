using FluentAssertions;
using StudyProject.Test.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StudyProject.Test.Domain
{
    public class EnderecoDomainTest
    {

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithEmptyCep(string cep)
        {
            var endereco = EnderecoBuilder.New().WithCep(cep).Build();

            endereco.Validations.Errors.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithEmptyRua(string rua)
        {
            var endereco = EnderecoBuilder.New().WithRua(rua).Build();

            endereco.Validations.Errors.Should().NotBeEmpty();    
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithEmptyNumero(string numero)
        {
            var endereco = EnderecoBuilder.New().WithNumero(numero).Build();

            endereco.Validations.Errors.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithEmptyBairro(string bairro)
        {
            var endereco = EnderecoBuilder.New().WithBairro(bairro).Build();

            endereco.Validations.Errors.Should().NotBeEmpty();
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithEmptyCidade(string cidade)
        {
            var endereco = EnderecoBuilder.New().WithRua(cidade).Build();

            endereco.Validations.Errors.Should().NotBeEmpty();
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithEmptyEstado(string estado)
        {
            var endereco = EnderecoBuilder.New().WithRua(estado).Build();

            endereco.Validations.Errors.Should().NotBeEmpty();
        }
       

    }
}
