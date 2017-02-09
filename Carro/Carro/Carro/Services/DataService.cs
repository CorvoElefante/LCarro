using System;
using System.Collections.Generic;
using Carro.Models;
using SQLite.Net;
using Carro.Repositories;
using System.Linq;

namespace Carro.Services
{
    public class DataService
    {
        public UnitOfWork UnitOfWork { get; private set; }

        public DataService(ISQLite sqlite)
        {
            UnitOfWork = new UnitOfWork(sqlite);
        }

        #region PessoaCliente

        public List<Pessoa> GetPessoas()
        {
            return UnitOfWork.PessoaRepository.GetAll().ToList();
        }

        public void SavePessoa(Pessoa pessoa)
        {
            UnitOfWork.PessoaRepository.AddOrUpdate(pessoa);
        }

        public List<Pessoa> FindPessoaByNome(string nome)
        {
            return UnitOfWork.PessoaRepository.Find(a => a.Nome.Contains(nome)).ToList();
        }

        #endregion

        #region Despesa
        #endregion

        #region Perda
        #endregion

        #region Funcionario
        #endregion

        #region Produto
        #endregion

        #region Servico
        #endregion
    }
}
