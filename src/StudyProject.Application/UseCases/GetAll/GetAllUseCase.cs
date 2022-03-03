using StudyProject.Application.Repositories;
using StudyProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyProject.Application.UseCases.GetAll
{
    public class GetAllUseCase : IGetAllUseCase
    {
        private readonly ICustomerRepository customerRepository;

        public GetAllUseCase(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
       
        public List<Customer> Execute()
        {
            var customerList = customerRepository.GetAll();
            
            return customerList;           

        }
    }
}
