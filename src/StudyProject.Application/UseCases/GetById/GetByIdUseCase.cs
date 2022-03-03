using StudyProject.Application.Repositories;
using StudyProject.Application.UseCases.Add;
using StudyProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyProject.Application.UseCases.GetById
{
    public class GetByIdUseCase : IGetByIdUseCase
    {
        private readonly ICustomerRepository customerRepository;

        public GetByIdUseCase(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public Customer Execute(GetByIdRequest request)
        {
            var customer = customerRepository.BuscarPorId(request.Id);

            return customer;
        }
    }
}
