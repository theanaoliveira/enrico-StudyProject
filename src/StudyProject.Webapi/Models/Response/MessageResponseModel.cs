namespace StudyProject.Webapi.Models.Response
{
    public class MessageResponseModel
    {
        public string Message { get; private set; }

        public MessageResponseModel(string message)
        {
            Message = message;
        }
    }
}
