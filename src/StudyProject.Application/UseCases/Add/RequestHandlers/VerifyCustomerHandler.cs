using StudyProject.Application.Repositories;

namespace StudyProject.Application.UseCases.Add.RequestHandlers
{
    public class VerifyCustomerHandler : Handler<AddRequest>
    {
        private readonly ICustomerRepository customerRepository;

        public VerifyCustomerHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public override void ProcessRequest(AddRequest request)
        {
            var customer = customerRepository.BuscarCliente(request.Rg, request.Cpf);

            if (customer != null)
            {
                request.Erros.Add("Já existe um cliente com esse rg: " + request.Rg + ", ou com esse cpf: " + request.Cpf);
                return;
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
