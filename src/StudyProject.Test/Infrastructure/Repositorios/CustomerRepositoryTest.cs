using FluentAssertions;
using StudyProject.Infrastructure.Repositorios;
using StudyProject.Test.Builders;
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
            var client = repositorio.BuscarPorNome(customer.FullName);

            retorno.Should().BeTrue();
            client.Should().NotBeNull();
        }

        [Fact]
        public void DeveAtualizarUmClienteNovoNoBanco()
        {
            var customer = CustomerBuilder.New().Build();
            var repositorio = new CustomerRepository();
            var retorno = repositorio.AdicionarCliente(customer);
            var endereco = EnderecoBuilder.New().WithId(customer.Endereco.Id).WithCustomerId(customer.Id).Build();

            customer = CustomerBuilder.New().WithId(customer.Id).WithFullName("Teste atualizar").WithEndereco(endereco).Build();

            var retorno1 = repositorio.AtualizarCliente(customer);
            var a = repositorio.BuscarPorNome("Teste atualizar");

            retorno.Should().BeTrue();
            retorno1.Should().BeTrue();
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
