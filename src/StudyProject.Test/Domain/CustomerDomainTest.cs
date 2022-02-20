using FluentAssertions;
using StudyProject.Test.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace StudyProject.Test.Domain
{
    public class CustomerDomainTest
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithEmptyFullname(string fullname)
        {
            var customer = CustomerBuilder.New().WithFullName(fullname).Build();

            customer.Validations.Errors.Should().NotBeEmpty();
            //customer.Validations.Errors.Select(s => s.ErrorMessage).Should().Contain("Nome completo não pode ser em branco");
        }

        [Fact]
        public void NotCreateWithLessThanMinimumBirthday()
        {
            var customer = CustomerBuilder.New().WithBirthday(DateTime.MinValue).Build();

            customer.Validations.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public void NotCreateWithMoreThanMaximumBirthday()
        {
            var customer = CustomerBuilder.New().WithBirthday(DateTime.MaxValue).Build();

            customer.Validations.Errors.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData("aaaaaaaaaaaaaaaa")]
        [InlineData("aaaaaaaaaaaaaa")]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithNot12CharactersRg(string rg)
        {
            var customer = CustomerBuilder.New().WithRg(rg).Build();

            customer.Validations.Errors.Should().NotBeEmpty();           
        }


        [Theory]
        [InlineData("aaaaaaaaaaaaaaaa")]
        [InlineData("aaaaaaaaaaaaaa")]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithNot14CharactersCpf(string cpf)
        {
            var customer = CustomerBuilder.New().WithCpf(cpf).Build();

            customer.Validations.Errors.Should().NotBeEmpty();         
        }

        
        [Fact]
       public void NotCreateWithLessThanMinimumRegisterDate()
        {
            var customer = CustomerBuilder.New().WithBirthday(DateTime.MinValue).Build();

            customer.Validations.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public void NotCreateWithMoreThanMaximumRegisterDate()
        {
            var customer = CustomerBuilder.New().WithBirthday(DateTime.MaxValue).Build();

            customer.Validations.Errors.Should().NotBeEmpty();
        }

    }
}
