using StudyProject.Domain;

namespace StudyProject.Application.Repositories
{
    public interface ICustomerRepository
    {
        bool AdicionarCliente(Customer customer);
        bool AtualizarCliente(Customer customer);
        Customer BuscarPorNome(string nome);
        Customer BuscarCliente(string rg, string cpf);
        bool DeletarCliente(Customer customer);
    }
}
