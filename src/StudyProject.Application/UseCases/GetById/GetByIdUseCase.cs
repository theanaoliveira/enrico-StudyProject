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

        public void Execute(GetByIdRequest request)
        {
            var endereco = new Endereco(request.Id, request.Cep, request.Rua, request.Numero, request.Complemento, request.Bairro, request.Cidade, request.Estado);
            var cliente = new Customer(request.Id, request.FullName, request.Birthday, request.Rg, request.Cpf, DateTime.Now, endereco, true);

            var clienteId = customerRepository.BuscarPorId(cliente.Id);

            if (clienteId != null)
                return 
                
        }
    }
}
