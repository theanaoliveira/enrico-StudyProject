using FluentAssertions;
using StudyProject.Infrastructure.Repositorios;
using StudyProject.Test.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StudyProject.Test.Infrastructure.Repositorios
{
    public class CustomerRepositoryTest 
    {
        [Fact]
        public void DeveAdicionarUmClienteNovoNoBanco()
        {
            var customer = CustomerBuilder.New().Build();

            var repositorio = new CustomerRepository();


            var retorno = repositorio.AdicionarCliente(customer);

            retorno.Should().BeTrue();

            var retorno2 = repositorio.AdicionarCliente(customer);

            retorno2.Should().BeFalse();

        }
    }
}
