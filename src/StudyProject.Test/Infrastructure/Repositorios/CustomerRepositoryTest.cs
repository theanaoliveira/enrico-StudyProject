using FluentAssertions;
using StudyProject.Application.Repositories;
using StudyProject.Domain;
using StudyProject.Infrastructure.Repositorios;
using StudyProject.Test.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace StudyProject.Test.Infrastructure.Repositorios
{
    [UseAutofacTestFramework]
    public class CustomerRepositoryTest
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerRepositoryTest(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [Fact]
        public void DeveAdicionarUmClienteNovoNoBanco()
        {
            var customer = CustomerBuilder.New().WithRg("787297389273").WithCpf("29837298732").Build();
            var retorno = customerRepository.AdicionarCliente(customer);

            retorno.Should().BeTrue();

        }

        [Fact]
        public void DeveAtualizarUmClienteNovoNoBanco()
        {
            var customer = CustomerBuilder.New().WithRg("147258369").WithCpf("15246895325").Build();

           

            var retorno = customerRepository.AdicionarCliente(customer);

            var endereco = EnderecoBuilder.New().WithId(customer.Endereco.Id).WithCustomerId(customer.Id).Build();

            customer = CustomerBuilder.New().WithId(customer.Id).WithFullName("Teste atualizar").WithEndereco(endereco).Build();

            var retorno1 = customerRepository.AtualizarCliente(customer);

            var a = customerRepository.BuscarPorNome("Teste atualizar");

            retorno.Should().BeTrue();
            retorno1.Should().BeTrue();
            a.Should().NotBeNull();
        }

        [Fact]
        public void DeveBuscarUmClienteNoBancoPorNome()
        {
            var customer = CustomerBuilder.New().WithRg("154872514").WithCpf("08197645281").Build();

            var retorno = customerRepository.AdicionarCliente(customer);

            retorno.Should().BeTrue();

            var a = customerRepository.BuscarPorNome("Test project domain");

            a.Should().NotBeNull();

        }

        [Fact]
        public void DeveBuscarUmClienteNoBancoPorId()
        {
            var customer = CustomerBuilder.New().WithRg("154872515").WithCpf("08197645282").Build();

           

            var retorno = customerRepository.AdicionarCliente(customer);

            retorno.Should().BeTrue();

            var a = customerRepository.BuscarPorId(customer.Id);

            a.Should().NotBeNull();

            //var listaClientes = new List<Customer>();

            //listaClientes.Add(customer);

            //customerRepository.AdicionarClientes(listaClientes);

        }

        [Fact]
        public void DeveBuscarTodosClienteNoBanco()
        {
            var customer = CustomerBuilder.New().WithRg("154872516").WithCpf("08197645283").Build();

            var customer1 = CustomerBuilder.New().WithRg("154872517").WithCpf("08197645284").Build();

            var customerList = CustomerBuilder.New().WithRg("154872518").WithCpf("08197645285").Build();

           


            customerRepository.AdicionarCliente(customer1);

            var a = customerRepository.GetAll();

            a.Should().NotBeNull();

            a.Should().HaveCountGreaterThan(1);
        }

        [Fact]
        public void DeveDeletarUmClienteNovoNoBanco()
        {
            var customer = CustomerBuilder.New().Build();

           

            customerRepository.AdicionarCliente(customer);

            var retorno = customerRepository.DeletarCliente(customer);

            retorno.Should().BeTrue();
        }
    }
}
