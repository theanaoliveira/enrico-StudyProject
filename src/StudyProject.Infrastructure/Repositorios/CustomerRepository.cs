using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudyProject.Application.Repositories;
using StudyProject.Domain;
using System;
using System.Collections.Generic;
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

            context.Customers.Add(customerEntity);

            var i = context.SaveChanges();

            return i > 0;
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
        
        //CTRL + k + d == identar o codigo

        public Customer BuscarPorId(Guid id)
        {
            using var context = new Context();

            var customer = context.Customers.Include(i => i.Endereco)
                .Where(w => w.Id == id).FirstOrDefault();

            return mapper.Map<Customer>(customer);
        }

        public bool AdicionarClientes(List<Customer> customers)
        {
            using var context = new Context();
            var customerEntity = mapper.Map<List<Entidades.Customer>>(customers);

            context.Customers.AddRange(customerEntity);

            var i = context.SaveChanges();

            return i > 0;
        }

        public List<Customer> GetAll()
        {
            using var context = new Context();
            var customers = context.Customers.ToList();

            return mapper.Map<List<Customer>>(customers);
        }

        public bool DeletarCliente(Customer customer)
        {
            using var context = new Context();

            var remover = context.Customers.Where(w => w.Id == customer.Id).FirstOrDefault();

            context.Customers.Remove(remover);

            var i = context.SaveChanges();

            return i > 0;
        }
    }
}

