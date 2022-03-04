using StudyProject.Application.Repositories;

namespace StudyProject.Application.UseCases.Update.RequestHandlers
{
    public class GetExistingCustomerHandler : Handler<UpdateRequest>
    {
        private readonly ICustomerRepository customerRepository;

        public GetExistingCustomerHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public override void ProcessRequest(UpdateRequest request)
        {
            request.Customer = customerRepository.BuscarPorId(request.Id);

            if (request.Customer == null)
                request.Erros.Add($"Cliente: {request.Id} não encontrado.");
            else if (!request.Customer.Ativo) 
                request.Erros.Add($"Cliente: {request.Id} desativado.");

            if (request.Erros.Count > 0) return;

            sucessor?.ProcessRequest(request);
        }
    }
}
