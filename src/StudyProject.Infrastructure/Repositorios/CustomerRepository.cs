using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudyProject.Application.Repositories;
using StudyProject.Domain;
using System.Linq;

namespace StudyProject.Infrastructure.Repositorios
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMapper mapper;

        public CustomerRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public bool AdicionarCliente(Customer customer)
        {
            using var context = new Context();
            var customerEntity = mapper.Map<Entidades.Customer>(customer);
            var customerDb = context.Customers.Where(w => w.Rg == customer.Rg || w.Cpf == customer.Cpf).ToList();

            if (customerDb.Count == 0)
            {
                context.Customers.Add(customerEntity);
                context.SaveChanges();

                return true;
            }

            return false;
        }

        public bool AtualizarCliente(Customer customer)
        {
            using var context = new Context();
            var customerEntity = mapper.Map<Entidades.Customer>(customer);

            context.Customers.Update(customerEntity);

            var i = context.SaveChanges();

            return i > 0;
        }

        public Customer BuscarCliente(string rg, string cpf)
        {
            using var context = new Context();
            var cliente = context.Customers.Where(w => (w.Cpf.Equals(cpf) || w.Rg.Equals(rg)) && w.Ativo).FirstOrDefault();

            return mapper.Map<Customer>(cliente);
        }

        public Customer BuscarPorNome(string nome)
        {
            using var context = new Context();
            var cliente = context.Customers
                .Include(i => i.Endereco)
                .Where(w => w.FullName == nome).FirstOrDefault();

            return mapper.Map<Customer>(cliente);
        }

        public bool DeletarCliente(Customer customer)
        {
            using var context = new Context();

            context.Customers.Remove(mapper.Map<Entidades.Customer>(customer));
            var i = context.SaveChanges();

            return i > 0;
        }
    }
}

