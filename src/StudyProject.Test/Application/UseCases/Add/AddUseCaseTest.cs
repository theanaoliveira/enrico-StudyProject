using FluentAssertions;
using StudyProject.Application.Repositories;
using StudyProject.Application.UseCases.Add;
using StudyProject.Test.Builders;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace StudyProject.Test.Application.UseCases.Add
{
    [UseAutofacTestFramework]
    public class AddUseCaseTest
    {
        private readonly IAddUseCase addUseCase;
        private readonly ICustomerRepository customerRepository;

        public AddUseCaseTest(IAddUseCase addUseCase, ICustomerRepository customerRepository)
        {
            this.addUseCase = addUseCase;
            this.customerRepository = customerRepository;
        }

        [Fact]
        public void DeveAdicionarUmCliente()
        {
            var request = new AddRequest("Ana Caroline", new DateTime(1993, 5, 27), "43.651.900-8", "318.303.700-90", "04571936", "Av. Engenheiro Luís Carlos Berrini", "1376", "", "Cidade Monções", "São Paulo", "São Paulo");

            addUseCase.Execute(request);

            var cliente = customerRepository.BuscarCliente(request.Rg, request.Cpf);

            request.Erros.Should().BeNullOrEmpty();

            cliente.Should().NotBeNull();
            cliente.FullName.Should().Be(request.FullName);
            cliente.Birthday.Should().Be(request.Birthday);
            cliente.Rg.Should().Be(request.Rg);
            cliente.Cpf.Should().Be(request.Cpf);
        }

        [Fact]
        public void NaoDeveAdicionarUmClienteSemNome()
        {
            var request = new AddRequest("", new DateTime(1993, 5, 27), "31.591.320-4", "743.608.540-99", "04571936", "Av. Engenheiro Luís Carlos Berrini", "1376", "", "Cidade Monções", "São Paulo", "São Paulo");

            addUseCase.Execute(request);

            var cliente = customerRepository.BuscarCliente(request.Rg, request.Cpf);

            request.Erros.Should().NotBeNullOrEmpty().And.HaveCountGreaterThanOrEqualTo(1);

            cliente.Should().BeNull();
        }

        [Fact]
        public void NaoDeveAdicionarUmClienteQueJaExiste()
        {

            var clienteExistente = CustomerBuilder.New().WithCpf("860.868.860-32").WithRg("44.774.404-5").Build();
            customerRepository.AdicionarCliente(clienteExistente);

            var request = new AddRequest("", new DateTime(1993, 5, 27), "", "860.868.860-32", "04571936", "Av. Engenheiro Luís Carlos Berrini", "1376", "", "Cidade Monções", "São Paulo", "São Paulo");

            addUseCase.Execute(request);

            var cliente = customerRepository.BuscarCliente(request.Rg, request.Cpf);

            request.Erros.Should().NotBeNullOrEmpty().And.Contain("Já existe um cliente com esse rg: " + request.Rg + ", ou com esse cpf: " + request.Cpf);

            cliente.Should().NotBeNull();
        }
    }
}
