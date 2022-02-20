using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudyProject.Domain;
using System.Linq;

namespace StudyProject.Infrastructure.Repositorios
{
    public class CustomerRepository
    {
        private IMapper CreateMap()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, Entidades.Customer>().ReverseMap();
                cfg.CreateMap<Endereco, Entidades.Endereco>().ReverseMap();
            }).CreateMapper();
        }

        public bool AdicionarCliente(Customer customer)
        {
            using var context = new Context();

            var map = CreateMap();
            var customerEntity = map.Map<Entidades.Customer>(customer);
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

            var map = CreateMap();
            var customerEntity = map.Map<Entidades.Customer>(customer);

            context.Customers.Update(customerEntity);

            var i = context.SaveChanges();

            return i > 0;
        }

        public Customer BuscarPorNome(string nome)
        {
            using var context = new Context();

            var map = CreateMap();
            var cliente = context.Customers
                .Include(i => i.Endereco)
                .Where(w => w.FullName == nome).FirstOrDefault();

            return map.Map<Customer>(cliente);
        }

        public bool DeletarCliente(Customer customer)
        {
            using var context = new Context();

            var enderecoEntity = new Entidades.Endereco()
            {
                Cep = customer.Endereco.Cep,
                Rua = customer.Endereco.Rua,
                Numero = customer.Endereco.Numero,
                Complemento = customer.Endereco.Complemento,
                Bairro = customer.Endereco.Bairro,
                Cidade = customer.Endereco.Cidade,
                Estado = customer.Endereco.Estado
            };

            var customerEntity = new Entidades.Customer()
            {
                FullName = customer.FullName,
                Rg = customer.Rg,
                Cpf = customer.Cpf,
                Birthday = customer.Birthday,
                RegisterDate = customer.RegisterDate,
                Endereco = enderecoEntity
            };

            var remover = context.Customers.Where(w => w.Id == customer.Id).FirstOrDefault();

            context.Customers.Remove(remover);

            var customerDb = context.Customers.Where(w => w.Rg == customer.Rg && w.Cpf == customer.Cpf).ToList();

            if (customerDb.Count == 0)
            {
                context.Customers.Add(customerEntity);
                context.SaveChanges();

                return true;
            }
            return false;

            var customerDb2 = context.Customers.Where(w => w.Rg == customer.Rg && w.Cpf == customer.Cpf).ToList();

            if (customerDb2.Count == 1)
            {

                context.Customers.Remove(customerEntity);
                context.SaveChanges();

                return true;
            }
            return false;


        }
    }
}

