using FluentAssertions;
using StudyProject.Application.Repositories;
using StudyProject.Application.UseCases.Add;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
