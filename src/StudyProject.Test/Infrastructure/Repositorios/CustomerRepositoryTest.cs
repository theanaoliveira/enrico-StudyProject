using FluentAssertions;
using StudyProject.Application.Repositories;
using StudyProject.Test.Builders;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace StudyProject.Test.Infrastructure.Repositorios
{
    [UseAutofacTestFramework]
    public class CustomerRepositoryTest
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerRepositoryTest(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [Fact]
        public void DeveAdicionarUmClienteNovoNoBanco()
        {
            var customer = CustomerBuilder.New().WithRg("223431485").WithCpf("84023371041").Build();
          
            var retorno = _customerRepository.AdicionarCliente(customer);
            var client = _customerRepository.BuscarPorNome(customer.FullName);

            retorno.Should().BeTrue();
            client.Should().NotBeNull();
        }

        [Fact]
        public void DeveAtualizarUmClienteNovoNoBanco()
        {
            var customer = CustomerBuilder.New().WithRg("163785892").WithCpf("55829931001").Build();
            var retorno = _customerRepository.AdicionarCliente(customer);
            var endereco = EnderecoBuilder.New().WithId(customer.Endereco.Id).Build();

            customer = CustomerBuilder.New().WithId(customer.Id).WithFullName("Teste atualizar").WithEndereco(endereco).Build();

            var retorno1 = _customerRepository.AtualizarCliente(customer);
            var a = _customerRepository.BuscarPorNome("Teste atualizar");

            retorno.Should().BeTrue();
            retorno1.Should().BeTrue();
            a.Should().NotBeNull();
        }
    }
}
