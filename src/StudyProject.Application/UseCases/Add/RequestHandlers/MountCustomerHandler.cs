using StudyProject.Domain;
using System;
using System.Linq;

namespace StudyProject.Application.UseCases.Add.RequestHandlers
{
    public class MountCustomerHandler : Handler<AddRequest>
    {
        public override void ProcessRequest(AddRequest request)
        {
            request.Customer = new Customer(Guid.NewGuid(), request.FullName, request.Birthday, request.Rg, request.Cpf, DateTime.Now, request.Endereco, true);

            if (request.Customer.Validations.Errors.Count > 0)
            {
                request.Erros.AddRange(request.Customer.Validations.Errors.Select(s => s.ErrorMessage).ToArray());
                return;
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
