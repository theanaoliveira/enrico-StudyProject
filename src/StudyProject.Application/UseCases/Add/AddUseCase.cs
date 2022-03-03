using StudyProject.Application.Repositories;
using StudyProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyProject.Application.UseCases.Add
{
    public class addUseCase : IAddUseCase
    {
        private readonly ICustomerRepository customerRepository;

        public addUseCase(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public void Execute(AddRequest request)
        {
            var endereco = new Endereco(Guid.NewGuid(), request.Cep, request.Rua, request.Numero, request.Complemento, request.Bairro, request.Cidade, request.Estado);
            var cliente = new Customer(Guid.NewGuid(), request.FullName, request.Birthday, request.Rg, request.Cpf, DateTime.Now, endereco, true);

            if (endereco.Validations.Errors.Count > 0)
                request.Erros.AddRange(endereco.Validations.Errors.Select(s => s.ErrorMessage).ToArray());

            if (cliente.Validations.Errors.Count > 0)
                request.Erros.AddRange(cliente.Validations.Errors.Select(s => s.ErrorMessage).ToArray());

            var clienteSalvo = customerRepository.BuscarCliente(request.Rg, request.Cpf);

            if (clienteSalvo != null)
                request.Erros.Add("Já existe um cliente com esse rg:" + request.Rg + ", ou com esse cpf:" + request.Cpf);

            if (request.Erros.Count == 0)
            customerRepository.AdicionarCliente(cliente);
        }
    }
}
