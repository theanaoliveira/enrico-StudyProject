using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudyProject.Application.Repositories;
using StudyProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyProject.Infrastructure.Repositorios
{
    public class CustomerRepository : ICustomerRepository
    {
        private IMapper CreateMap()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, Entidades.Customer>().ReverseMap();
                cfg.CreateMap<Endereco, Entidades.Endereco>().ReverseMap();
            }).CreateMapper();
        }

        private readonly IMapper mapper;

        public CustomerRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public bool AdicionarCliente(Customer customer)
        {
            using var context = new Context();

            var map = CreateMap();
            var customerEntity = map.Map<Entidades.Customer>(customer);

            context.Customers.Add(customerEntity);
            var i = context.SaveChanges();

            return i > 0;
        }

        public bool AdicionarClientes(List<Customer> customers)
        {
            using var context = new Context();
            var map = CreateMap();
            var customerEntity = map.Map<List<Entidades.Customer>>(customers);

            context.Customers.AddRange(customerEntity);
            var i = context.SaveChanges();

            return i > 0;
        }

        public bool AtualizarCliente(Customer customer)
        {
            using var context = new Context();

            var map = CreateMap();

            var customerEntity = map.Map<Entidades.Customer>(customer);

            context.Customers.Update(customerEntity);

            var i = context.SaveChanges();

            return i > 0;
        }

        public List<Customer> GetAll()
        {
            using var context = new Context();

            var map = CreateMap();

            var customerList = context.Customers.Include(i => i.Endereco).ToList();

            return map.Map<List<Customer>>(customerList);
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

            var map = CreateMap();

            var customer = context.Customers.Include(i => i.Endereco)
                .Where(w => w.FullName == nome).FirstOrDefault();

            return map.Map<Customer>(customer);
        }

        //CTRL + k + d == identar o codigo

        public Customer BuscarPorId(Guid id)
        {
            using var context = new Context();

            var map = CreateMap();

            var customer = context.Customers.Include(i => i.Endereco)
                .Where(w => w.Id == id).FirstOrDefault();

            return map.Map<Customer>(customer);
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

