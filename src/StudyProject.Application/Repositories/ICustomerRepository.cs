using StudyProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyProject.Application.Repositories
{
    public interface ICustomerRepository
    {
        bool AdicionarCliente(Customer customer);
        bool AdicionarClientes(List<Customer> customers);
        bool AtualizarCliente(Customer customer);
        List<Customer> GetAll();
        Customer BuscarPorNome(string nome);
        Customer BuscarPorId(Guid id);
        Customer BuscarCliente(string Rg, string Cpf);
        bool DeletarCliente(Customer customer);
    }
}
