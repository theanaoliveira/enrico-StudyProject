using StudyProject.Domain;
using System;
using System.Linq;

namespace StudyProject.Application.UseCases.Add.RequestHandlers
{
    public class MountAddressHandler : Handler<AddRequest>
    {
        public override void ProcessRequest(AddRequest request)
        {
            request.Endereco = new Endereco(Guid.NewGuid(), request.Cep, request.Rua, request.Numero, request.Complemento, request.Bairro, request.Cidade, request.Estado);

            if (request.Endereco.Validations.Errors.Count > 0)
            {
                request.Erros.AddRange(request.Endereco.Validations.Errors.Select(s => s.ErrorMessage).ToArray());
                return;
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
