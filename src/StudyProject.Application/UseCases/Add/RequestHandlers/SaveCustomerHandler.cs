using StudyProject.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyProject.Application.UseCases.Add.RequestHandlers
{
    public class SaveCustomerHandler : Handler<AddRequest>
    {
        private readonly ICustomerRepository customerRepository;

        public SaveCustomerHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public override void ProcessRequest(AddRequest request)
        {
            customerRepository.AdicionarCliente(request.Customer);

            sucessor?.ProcessRequest(request);
        }
    }
}
