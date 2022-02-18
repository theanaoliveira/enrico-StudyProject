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

        [Fact]
        public void DeveAtualizarUmClienteNovoNoBanco()
        {
            var customer = CustomerBuilder.New().Build();

            var repositorio = new CustomerRepository();

            var retorno = repositorio.AdicionarCliente(customer);

            retorno.Should().BeTrue();

            customer = CustomerBuilder.New().WithId(customer.Id).WithFullName("Teste atualizar").Build();

            var retorno1 = repositorio.AtualizarCliente(customer);

            var a = repositorio.BuscarPorNome("Teste atualizar");


            a.Should().NotBeNull();

        }

        [Fact]
        public void DeveDeletarUmClienteNovoNoBanco()
        {
            var customer = CustomerBuilder.New().Build();

            var repositorio = new CustomerRepository();


            var retorno = repositorio.DeletarCliente(customer);

            retorno.Should().BeTrue();

            var retorno2 = repositorio.DeletarCliente(customer);

            retorno2.Should().BeFalse();
        }
    }
}
