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
        private readonly ICustomerRepository customerRepository;

        public CustomerRepositoryTest(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [Fact]
        public void DeveAdicionarUmClienteNovoNoBanco()
        {
            var customer = CustomerBuilder.New().WithRg("223431485").WithCpf("84023371041").Build();
          
            var retorno = customerRepository.AdicionarCliente(customer);
            var client = customerRepository.BuscarPorNome(customer.FullName);

            retorno.Should().BeTrue();
            client.Should().NotBeNull();
        }

        [Fact]
        public void DeveAtualizarUmClienteNovoNoBanco()
        {
            var customer = CustomerBuilder.New().WithRg("163785892").WithCpf("55829931001").Build();
            var endereco = EnderecoBuilder.New().WithId(customer.Endereco.Id).Build();

            customerRepository.AdicionarCliente(customer);
            
            customer = CustomerBuilder.New().WithId(customer.Id).WithFullName("Teste atualizar").WithEndereco(endereco).Build();

            var retorno1 = customerRepository.AtualizarCliente(customer);
            var a = customerRepository.BuscarPorNome("Teste atualizar");

            retorno1.Should().BeTrue();
            a.Should().NotBeNull();
        }
    }
}
