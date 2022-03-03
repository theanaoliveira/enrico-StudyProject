using StudyProject.Application.Repositories;

namespace StudyProject.Application.UseCases.Update.RequestHandlers
{
    public class VerifyCustomerHandler : Handler<UpdateRequest>
    {
        private readonly ICustomerRepository customerRepository;

        public VerifyCustomerHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public override void ProcessRequest(UpdateRequest request)
        {
            var customer = customerRepository.BuscarCliente(request.Rg, request.Cpf);

            if (customer != null && !customer.Id.Equals(request.Id))
            {
                request.Erros.Add("Já existe um cliente com esse rg: " + request.Rg + ", ou com esse cpf: " + request.Cpf);
                return;
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
