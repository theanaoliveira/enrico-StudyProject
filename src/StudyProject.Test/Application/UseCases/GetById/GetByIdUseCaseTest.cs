using FluentAssertions;
using StudyProject.Application.Repositories;
using StudyProject.Application.UseCases.Add;
using StudyProject.Application.UseCases.GetById;
using StudyProject.Domain;
using StudyProject.Test.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace StudyProject.Test.Application.UseCases.GetById
{
    [UseAutofacTestFramework]
    public class GetByIdUseCaseTest
    {
        private readonly IGetByIdUseCase getByIdUseCase;
        private readonly ICustomerRepository customerRepository;

        public GetByIdUseCaseTest(IGetByIdUseCase getByIdUseCase, ICustomerRepository customerRepository)
        {
            this.getByIdUseCase = getByIdUseCase;
            this.customerRepository = customerRepository;
        }

        [Fact]
        public void DeveBuscarPorId()
        {
            var cliente = CustomerBuilder.New().Build();

            customerRepository.AdicionarCliente(cliente);

            var request = new GetByIdRequest(cliente.Id);

            var a = getByIdUseCase.Execute(request.Id);

            var b = customerRepository.BuscarPorId(request.Id);

            a.Should().NotBeNull();
            b.Should().NotBeNull();

        }
    }
}
