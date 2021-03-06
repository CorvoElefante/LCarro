﻿using Carro.Models;
using Carro.Repositories.Interfaces;
using SQLite.Net;

namespace Carro.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(SQLiteConnection sqlite)
        {
            DB = sqlite;

            _LoginRepository = new GenericRepository<Login, long>(DB, DBLocker);
            _PessoaRepository = new GenericRepository<Pessoa, long>(DB, DBLocker);
            _DespesaRepository = new GenericRepository<Despesa, long>(DB, DBLocker);
            _FuncionarioRepository = new GenericRepository<Funcionario, long>(DB, DBLocker);
            _ProdutoRepository = new GenericRepository<Produto, long>(DB, DBLocker);
            _PerdaRepository = new GenericRepository<Perda, long>(DB, DBLocker);
            _ServicoRepository = new GenericRepository<Servico, long>(DB, DBLocker);
            _PerdaProdutoRepository = new GenericRepository<PerdaProduto, long>(DB, DBLocker);
            _FuncionarioServicoRepository = new GenericRepository<FuncionarioServico, long>(DB, DBLocker);
            _OrdemVendaProdutoRepository = new GenericRepository<OrdemVendaProduto, long>(DB, DBLocker);
            _OrdemVendaServicoRepository = new GenericRepository<OrdemVendaServico, long>(DB, DBLocker);
            _OrdemVendaParcelaRepository = new GenericRepository<OrdemVendaParcela, long>(DB, DBLocker);
            _OrdemVendaRepository = new GenericRepository<OrdemVenda, long>(DB, DBLocker);

            lock (DBLocker)
            {
                DB.CreateTable<Login>();
                DB.CreateTable<Pessoa>();
                DB.CreateTable<Despesa>();
                DB.CreateTable<Funcionario>();
                DB.CreateTable<Produto>();
                DB.CreateTable<Perda>();
                DB.CreateTable<Servico>();
                DB.CreateTable<PerdaProduto>();
                DB.CreateTable<FuncionarioServico>();
                DB.CreateTable<OrdemVendaProduto>();
                DB.CreateTable<OrdemVendaServico>();
                DB.CreateTable<OrdemVendaParcela>();
                DB.CreateTable<OrdemVenda>();
            }
        }

        static object DBLocker = new object();
        readonly SQLiteConnection DB;

        #region Login
        IGenericRepository<Login, long> _LoginRepository;
        public IGenericRepository<Login, long> LoginRepository
        {
            get
            {
                return _LoginRepository;
            }
        }
        #endregion

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

        #region PerdaProduto
        IGenericRepository<PerdaProduto, long> _PerdaProdutoRepository;
        public IGenericRepository<PerdaProduto, long> PerdaProdutoRepository
        {
            get
            {
                return _PerdaProdutoRepository;
            }
        }
        #endregion

        #region FuncionarioServico

        IGenericRepository<FuncionarioServico, long> _FuncionarioServicoRepository;
        public IGenericRepository<FuncionarioServico, long> FuncionarioServicoRepository
        {
            get
            {
                return _FuncionarioServicoRepository;
            }
        }

        #endregion

        #region OrdemVendaProduto

        IGenericRepository<OrdemVendaProduto, long> _OrdemVendaProdutoRepository;
        public IGenericRepository<OrdemVendaProduto, long> OrdemVendaProdutoRepository
        {
            get
            {
                return _OrdemVendaProdutoRepository;
            }
        }

        #endregion

        #region OrdemvendaServico

        IGenericRepository<OrdemVendaServico, long> _OrdemVendaServicoRepository;
        public IGenericRepository<OrdemVendaServico, long> OrdemVendaServicoRepository
        {
            get
            {
                return _OrdemVendaServicoRepository;
            }
        }

        #endregion

        #region OrdemvendaParcela

        IGenericRepository<OrdemVendaParcela, long> _OrdemVendaParcelaRepository;
        public IGenericRepository<OrdemVendaParcela, long> OrdemVendaParcelaRepository
        {
            get
            {
                return _OrdemVendaParcelaRepository;
            }
        }

        #endregion

        #region Ordemvenda

        IGenericRepository<OrdemVenda, long> _OrdemVendaRepository;
        public IGenericRepository<OrdemVenda, long> OrdemVendaRepository
        {
            get
            {
                return _OrdemVendaRepository;
            }
        }

        #endregion

    }
}
