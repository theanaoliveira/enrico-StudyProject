using StudyProject.Application.Repositories;

namespace StudyProject.Application.UseCases.Delete
{
    public class DeleteUseCase : IDeleteUseCase
    {
        private readonly ICustomerRepository customerRepository;

        public DeleteUseCase(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public bool Execute(DeleteRequest request)
        {
            request.Customer = customerRepository.BuscarPorId(request.Id);

            if (request.Customer != null)
            {
                request.Customer.SetStatus(false);
                customerRepository.AtualizarCliente(request.Customer);

                return true;
            }

            return false;
        }
    }
}
