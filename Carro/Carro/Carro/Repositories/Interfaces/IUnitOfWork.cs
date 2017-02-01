using Carro.Models;
namespace Carro.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Pessoa, long> PessoaRepository { get; }
    }
}
