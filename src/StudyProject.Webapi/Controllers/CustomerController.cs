using Microsoft.AspNetCore.Mvc;
using StudyProject.Application.UseCases.Add;
using StudyProject.Application.UseCases.Delete;
using StudyProject.Application.UseCases.GetAll;
using StudyProject.Application.UseCases.GetById;
using StudyProject.Application.UseCases.Update;
using StudyProject.Webapi.Models.Request;
using StudyProject.Webapi.Models.Response;
using System;
using System.Collections.Generic;

namespace StudyProject.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IAddUseCase addUseCase;
        private readonly IGetAllUseCase getAllUseCase;
        private readonly IGetByIdUseCase getByIdUseCase;
        private readonly IUpdateUseCase updateUseCase;
        private readonly IDeleteUseCase deleteUseCase;

        public CustomerController(IAddUseCase addUseCase, IGetAllUseCase getAllUseCase, IGetByIdUseCase getByIdUseCase, IUpdateUseCase updateUseCase, IDeleteUseCase deleteUseCase)
        {
            this.addUseCase = addUseCase;
            this.getAllUseCase = getAllUseCase;
            this.getByIdUseCase = getByIdUseCase;
            this.updateUseCase = updateUseCase;
            this.deleteUseCase = deleteUseCase;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(List<string>), 400)]
        [Route("Add")]
        public IActionResult AddCustomer([FromBody] AddCustomerModel input)
        {
            var request = new AddRequest(input.FullName,
                input.Birthday,
                input.Rg,
                input.Cpf,
                input.ZipCode,
                input.Street,
                input.Number,
                input.Complement,
                input.Neighborhood,
                input.City,
                input.State);

            addUseCase.Execute(request);

            if (request.Erros.Count > 0)
                return BadRequest(request.Erros);

            return Ok(request.Customer.Id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CustomerResponseModel>), 200)]
        [ProducesResponseType(typeof(MessageResponseModel), 404)]
        [Route("GetAll")]
        public IActionResult GetAllCustomers()
        {
            var response = new List<CustomerResponseModel>();
            var customers = getAllUseCase.Execute();

            customers.ForEach(f =>
            {
                var end = new AddressResponseModel(f.Endereco.Id, f.Endereco.Cep, f.Endereco.Rua, f.Endereco.Numero, f.Endereco.Complemento, f.Endereco.Bairro, f.Endereco.Cidade, f.Endereco.Estado);

                response.Add(new CustomerResponseModel(f.Id, f.FullName, f.Birthday, f.Rg, f.Cpf, f.RegisterDate, end, f.Ativo));
            });

            if (response.Count > 0) return Ok(response);
            else return NotFound(new MessageResponseModel("Nenhum cliente encontrado."));
        }

        [HttpGet]
        [ProducesResponseType(typeof(CustomerResponseModel), 200)]
        [ProducesResponseType(typeof(MessageResponseModel), 400)]
        [Route("Get/{id}")]
        public IActionResult GetCustomer(Guid id)
        {
            var customer = getByIdUseCase.Execute(new GetByIdRequest(id));

            if (customer != null)
            {
                var end = new AddressResponseModel(customer.Endereco.Id, customer.Endereco.Cep, customer.Endereco.Rua, customer.Endereco.Numero, customer.Endereco.Complemento, customer.Endereco.Bairro, customer.Endereco.Cidade, customer.Endereco.Estado);
                var response = new CustomerResponseModel(customer.Id, customer.FullName, customer.Birthday, customer.Rg, customer.Cpf, customer.RegisterDate, end, customer.Ativo);

                return Ok(response);
            }
            else
            {
                return BadRequest(new MessageResponseModel($"Não existe nenhum cliente com o id: {id}"));
            }
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        [ProducesResponseType(typeof(MessageResponseModel), 200)]
        [ProducesResponseType(typeof(List<string>), 400)]
        public IActionResult UpdateCustomer([FromBody] UpdateCustomerModel input)
        {
            var request = new UpdateRequest(input.Id, input.FullName, input.Birthday, input.Rg, input.Cpf, input.ZipCode, input.Street, input.Number, input.Complement, input.Neighborhood, input.City, input.State);

            updateUseCase.Execute(request);

            if (request.Erros.Count > 0)
                return BadRequest(request.Erros);

            return Ok(new MessageResponseModel("Cliente atualizado com sucesso."));
        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        [ProducesResponseType(typeof(MessageResponseModel), 200)]
        [ProducesResponseType(typeof(MessageResponseModel), 400)]
        public IActionResult DeleteCustomer([FromBody] DeleteCustomerModel input)
        {
            var retorno = deleteUseCase.Execute(new DeleteRequest(input.Id));

            if (retorno) return Ok(new MessageResponseModel("Cliente desativado com sucesso."));
            else return BadRequest(new MessageResponseModel("Cliente não encontrado."));
        }
    }
}
