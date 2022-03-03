using Microsoft.AspNetCore.Mvc;
using StudyProject.Application.UseCases.Add;
using StudyProject.Webapi.Models;
using System;

namespace StudyProject.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IAddUseCase addUseCase;

        public CustomerController(IAddUseCase addUseCase)
        {
            this.addUseCase = addUseCase;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        [Route("Add")]
        public IActionResult AddCustomer([FromBody] AddCustomerModel input)
        {
            var request = new AddRequest(input.FullName,
                input.Birthday,
                input.Rg,
                input.Cpf,
                input.Cep,
                input.Rua,
                input.Numero,
                input.Complemento,
                input.Bairro,
                input.Cidade,
                input.Estado);

            addUseCase.Execute(request);

            if (request.Erros.Count > 0)
                return BadRequest(request.Erros);

            return Ok(request.Customer.Id);
        }
    }
}
