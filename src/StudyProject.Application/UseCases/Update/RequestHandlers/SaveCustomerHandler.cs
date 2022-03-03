using StudyProject.Application.Repositories;

namespace StudyProject.Application.UseCases.Update.RequestHandlers
{
    public class SaveCustomerHandler : Handler<UpdateRequest>
    {
        private readonly ICustomerRepository customerRepository;

        public SaveCustomerHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public override void ProcessRequest(UpdateRequest request)
        {
            customerRepository.AtualizarCliente(request.UpdCustomer);

            sucessor?.ProcessRequest(request);
        }
    }
}
