using Microsoft.EntityFrameworkCore;
using StudyProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyProject.Infrastructure.Repositorios
{
    public class CustomerRepository
    {
        private Entidades.Endereco MontarEndereco(Customer customer)
        {
            var enderecoEntity = new Entidades.Endereco()
            {
                Id = customer.Endereco.Id,
                Cep = customer.Endereco.Cep,
                Rua = customer.Endereco.Rua,
                Numero = customer.Endereco.Numero,
                Complemento = customer.Endereco.Complemento,
                Bairro = customer.Endereco.Bairro,
                Cidade = customer.Endereco.Cidade,
                Estado = customer.Endereco.Estado
            };

            return enderecoEntity;
        }


        public bool AdicionarCliente(Customer customer)
        {
            using var context = new Context();

            //todo: Criar metodos para Atualizar, Deletar e Consultar e retornar tudo que foi salvo

            var enderecoEntity = MontarEndereco(customer);


            var customerEntity = new Entidades.Customer()
            {
                Id = customer.Id,
                FullName = customer.FullName,
                Rg = customer.Rg,
                Cpf = customer.Cpf,
                Birthday = customer.Birthday,
                RegisterDate = customer.RegisterDate,
                EnderecoId = enderecoEntity.Id,
                Endereco = enderecoEntity
            };

            var customerDb = context.Customers.Where(w => w.Rg == customer.Rg || w.Cpf == customer.Cpf).ToList();

            if (customerDb.Count == 0)
            {
                context.Entry<Entidades.Endereco>(customerEntity.Endereco);
                context.Customers.Add(customerEntity);
                context.SaveChanges();

                return true;
            }
            return false;

        }

        public bool AtualizarCliente(Customer customer)
        {
            using var context = new Context();

            var enderecoEntity = MontarEndereco(customer);

            var customerEntity = new Entidades.Customer()
            {
                Id = customer.Id,
                FullName = customer.FullName,
                Rg = customer.Rg,
                Cpf = customer.Cpf,
                Birthday = customer.Birthday,
                EnderecoId = enderecoEntity.Id,
                //Endereco = enderecoEntity,
                RegisterDate = customer.RegisterDate,
            };



            context.Customers.Update(customerEntity);
            var i = context.SaveChanges();

            return true;

        }


        public Customer BuscarPorNome(string nome)
        {
            using var context = new Context();

            var cliente = context.Customers
                //.Include(i => i.Endereco)
                .Where(w => w.FullName == nome).FirstOrDefault();

            if (cliente != null)
            {
                //var endereco = new Endereco(cliente.Endereco.Id, cliente.Endereco.Cep, cliente.Endereco.Rua,
                // cliente.Endereco.Numero, cliente.Endereco.Complemento, cliente.Endereco.Bairro, cliente.Endereco.Cidade,
                //  cliente.Endereco.Estado);

                var customerDomain = new Customer(cliente.Id, cliente.FullName, cliente.Birthday, cliente.Rg,
                    cliente.Cpf, cliente.RegisterDate, null, cliente.Ativo);

                return customerDomain;
            }
            return null;
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

            var remover =  context.Customers.Where(w => w.Id == customer.Id).FirstOrDefault();

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

