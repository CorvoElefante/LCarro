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
            _DespesaRepository = new GenericRepository<Despesa, long>(DB, DBLocker);
            _FuncionarioRepository = new GenericRepository<Funcionario, long>(DB, DBLocker);
            _PerdaRepository = new GenericRepository<Perda, long>(DB, DBLocker);
            _ProdutoRepository = new GenericRepository<Produto, long>(DB, DBLocker);
            _ServicoRepository = new GenericRepository<Servico, long>(DB, DBLocker);

            lock (DBLocker)
            {
                DB.CreateTable<Pessoa>();
                DB.CreateTable<Despesa>();
                DB.CreateTable<Funcionario>();
                DB.CreateTable<Perda>();
                DB.CreateTable<Produto>();
                DB.CreateTable<Servico>();
            }
        }

        static object DBLocker = new object();
        readonly SQLiteConnection DB;

        #region Pessoa
        IGenericRepository<Pessoa, long> _PessoaRepository;
        public IGenericRepository<Pessoa, long> PessoaRepository
        {
            get
            {
                return _PessoaRepository;
            }
        }
        #endregion

        #region Despesa
        IGenericRepository<Despesa, long> _DespesaRepository;
        public IGenericRepository<Despesa, long> DespesaRepository
        {
            get
            {
                return _DespesaRepository;
            }
        }
        #endregion

        #region Funcionario
        IGenericRepository<Funcionario, long> _FuncionarioRepository;
        public IGenericRepository<Funcionario, long> FuncionarioRepository
        {
            get
            {
                return _FuncionarioRepository;
            }
        }
        #endregion

        #region Perda
        IGenericRepository<Perda, long> _PerdaRepository;
        public IGenericRepository<Perda, long> PerdaRepository
        {
            get
            {
                return _PerdaRepository;
            }
        }
        #endregion

        #region Produto
        IGenericRepository<Produto, long> _ProdutoRepository;
        public IGenericRepository<Produto, long> ProdutoRepository
        {
            get
            {
                return _ProdutoRepository;
            }
        }
        #endregion

        #region Servico
        IGenericRepository<Servico, long> _ServicoRepository;
        public IGenericRepository<Servico, long> ServicoRepository
        {
            get
            {
                return _ServicoRepository;
            }
        }
        #endregion
    }
}
