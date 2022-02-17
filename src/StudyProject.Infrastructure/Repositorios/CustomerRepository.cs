using StudyProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyProject.Infrastructure.Repositorios
{
    public class CustomerRepository
    {
        public bool AdicionarCliente(Customer customer)
        {
            using var context = new Context();

            //todo: Criar metodos para Atualizar, Deletar e Consultar e retornar tudo que foi salvo


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

            var customerEntity = new Entidades.Customer()
            {
                Id = customer.Id,
                FullName = customer.FullName,
                Rg = customer.Rg,
                Cpf = customer.Cpf,
                Birthday = customer.Birthday,
                RegisterDate = customer.RegisterDate,
                Endereco = enderecoEntity
            };

            var customerDb = context.Customers.Where(w => w.Rg == customer.Rg || w.Cpf == customer.Cpf).ToList();

            if (customerDb.Count == 0)
            {
                context.Customers.Add(customerEntity);
                context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
