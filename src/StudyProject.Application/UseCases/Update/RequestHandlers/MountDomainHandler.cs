using StudyProject.Domain;
using System.Linq;

namespace StudyProject.Application.UseCases.Update.RequestHandlers
{
    public class MountDomainHandler : Handler<UpdateRequest>
    {
        public override void ProcessRequest(UpdateRequest request)
        {
            request.UpdEndereco = new Endereco(request.Customer.Endereco.Id, request.Cep, request.Rua, request.Numero, request.Complemento, request.Bairro, request.Cidade, request.Estado);
            request.UpdCustomer = new Customer(request.Id, request.FullName, request.Birthday, request.Rg, request.Cpf, request.Customer.RegisterDate, request.UpdEndereco, request.Customer.Ativo);

            if (request.UpdEndereco.Validations.Errors.Count > 0)
                request.Erros.AddRange(request.UpdEndereco.Validations.Errors.Select(s => s.ErrorMessage).ToArray());

            if (request.UpdCustomer.Validations.Errors.Count > 0)
                request.Erros.AddRange(request.UpdCustomer.Validations.Errors.Select(s => s.ErrorMessage).ToArray());

            if (request.Erros.Count > 0) return;

            sucessor?.ProcessRequest(request);
        }
    }
}
