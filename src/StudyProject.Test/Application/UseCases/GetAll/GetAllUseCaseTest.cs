using FluentAssertions;
using StudyProject.Application.Repositories;
using StudyProject.Application.UseCases.Add;
using StudyProject.Application.UseCases.GetAll;
using StudyProject.Domain;
using StudyProject.Test.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace StudyProject.Test.Application.UseCases.GetAll
{
    [UseAutofacTestFramework]
    public class GetAllUseCaseTest
    {
        private readonly IGetAllUseCase getAllUseCase;
        private readonly ICustomerRepository customerRepository;

        public GetAllUseCaseTest(IGetAllUseCase getAllUseCase, ICustomerRepository customerRepository)
        {
            this.getAllUseCase = getAllUseCase;
            this.customerRepository = customerRepository;
        }

        [Fact]
        public void DeveBuscarTodosClientes()
        {
            var customer1 = CustomerBuilder.New().WithRg("154872516").WithCpf("08197645283").Build();
            var customer2 = CustomerBuilder.New().WithRg("154872517").WithCpf("08197645284").Build();
            var customer3 = CustomerBuilder.New().WithRg("154872518").WithCpf("08197645285").Build();

            customerRepository.AdicionarCliente(customer1);
            customerRepository.AdicionarCliente(customer2);
            customerRepository.AdicionarCliente(customer3);

            List<Customer> clientes = getAllUseCase.Execute();

            clientes.Should().NotBeNull();
            clientes.Should().HaveCountGreaterThan(1);
        }
    }
}
