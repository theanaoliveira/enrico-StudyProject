using StudyProject.Application.UseCases.Add.RequestHandlers;

namespace StudyProject.Application.UseCases.Add
{
    public class AddUseCase : IAddUseCase
    {
        private readonly MountAddressHandler mountAddressHandler;

        public AddUseCase(MountAddressHandler mountAddressHandler, MountCustomerHandler mountCustomerHandler, VerifyCustomerHandler verifyCustomerHandler, SaveCustomerHandler saveCustomerHandler)
        {
            mountAddressHandler.SetSucessor(mountCustomerHandler);
            mountCustomerHandler.SetSucessor(verifyCustomerHandler);
            verifyCustomerHandler.SetSucessor(saveCustomerHandler);

            this.mountAddressHandler = mountAddressHandler;
        }

        public void Execute(AddRequest request)
        {
            mountAddressHandler.ProcessRequest(request);
        }
    }
}
