namespace StudyProject.Application.UseCases
{
    public abstract class Handler<T>
    {
        public Handler<T> sucessor;

        public void SetSucessor(Handler<T> sucessor)
        {
            this.sucessor = sucessor;
        }

        public abstract void ProcessRequest(T request);
    }
}
