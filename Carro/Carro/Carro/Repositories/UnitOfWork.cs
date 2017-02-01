using Carro.Models;
using Carro.Repositories.Interfaces;
using SQLite.Net;

namespace Carro.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ISQLite sqlite)
        {
            DB = sqlite.GetConnection();

            _PessoaRepository = new GenericRepository<Pessoa, long>(DB, DBLocker);

            lock (DBLocker)
            {
                DB.CreateTable<Pessoa>();
            }
        }

        static object DBLocker = new object();
        readonly SQLiteConnection DB;

        IGenericRepository<Pessoa, long> _PessoaRepository;
        public IGenericRepository<Pessoa, long> PessoaRepository
        {
            get
            {
                return _PessoaRepository;
            }
        }
    }
}
