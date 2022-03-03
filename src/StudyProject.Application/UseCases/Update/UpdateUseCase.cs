using StudyProject.Application.UseCases.Update.RequestHandlers;

namespace StudyProject.Application.UseCases.Update
{
    public class UpdateUseCase : IUpdateUseCase
    {
        private readonly GetExistingCustomerHandler getExistingCustomerHandler;

        public UpdateUseCase(GetExistingCustomerHandler getExistingCustomerHandler, MountDomainHandler mountDomainHandler, VerifyCustomerHandler verifyCustomerHandler, SaveCustomerHandler saveCustomerHandler)
        {
            getExistingCustomerHandler.SetSucessor(mountDomainHandler);
            mountDomainHandler.SetSucessor(verifyCustomerHandler);
            verifyCustomerHandler.SetSucessor(saveCustomerHandler);

            this.getExistingCustomerHandler = getExistingCustomerHandler;
        }

        public void Execute(UpdateRequest request)
        {
            getExistingCustomerHandler.ProcessRequest(request);
        }
    }
}
