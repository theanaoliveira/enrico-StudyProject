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
       
        public Execute(GetAllRequest request)
        {            
            var listaClientes = customerRepository.GetAll();

            request.ListaCliente.AddRange(listaClientes)


            return <List<Customer>>(listaClientes);

            

        }
    }
}
