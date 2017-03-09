using System;
using System.Collections.Generic;
using Carro.Models;
using SQLite.Net;
using Carro.Repositories;
using System.Linq;
using SQLiteNetExtensions.Extensions;

namespace Carro.Services
{
    public class DataService
    {
        public UnitOfWork UnitOfWork { get; private set; }

        public DataService(ISQLite sqlite)
        {
            DB = sqlite.GetConnection();
            UnitOfWork = new UnitOfWork(DB);
            
        }
        readonly SQLiteConnection DB;

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

        public void DeletePessoa(Pessoa pessoa)
        {
            UnitOfWork.PessoaRepository.Delete(pessoa);
        }

        #endregion

        #region Despesa

        public List<Despesa> GetDespesas()
        {
            return UnitOfWork.DespesaRepository.GetAll().ToList();
        }

        public void SaveDespesa(Despesa despesa)
        {
            UnitOfWork.DespesaRepository.AddOrUpdate(despesa);
        }

        public List<Despesa> FindDespesaByNome(string nome)
        {
            return UnitOfWork.DespesaRepository.Find(a => a.Nome.Contains(nome)).ToList();
        }

        #endregion

        #region Perda

        public List<Perda> GetPerdas()
        {
            return UnitOfWork.PerdaRepository.GetAll().ToList();
        }

        public void SavePerda(Perda perda)
        {
            UnitOfWork.PerdaRepository.AddOrUpdate(perda);
        }

        public List<Perda> FindPerdaByNome(string nome)
        {
            return UnitOfWork.PerdaRepository.Find(a => a.Nome.Contains(nome)).ToList();
        }

        #endregion

        #region Funcionario

        public List<Funcionario> GetFuncionarios()
        {
            return UnitOfWork.FuncionarioRepository.GetAll().ToList();
        }

        public void SaveFuncionario(Funcionario funcionario)
        {
            UnitOfWork.FuncionarioRepository.AddOrUpdate(funcionario);
        }

        public List<Funcionario> FindFuncionarioByNome(string nome)
        {
            List<Funcionario> list = new List<Funcionario>();
            var elements = DB.Table<Funcionario>();
            if (nome == null || nome == "")
            {
                list = DB.Query<Funcionario>("SELECT funcionario.Id, funcionario.Salario, funcionario.Funcao, funcionario.PessoaId FROM funcionario INNER JOIN pessoa ON funcionario.PessoaId = Pessoa.Id").ToList();
            }
            else
            {
                list = DB.Query<Funcionario>("SELECT funcionario.Id, funcionario.Salario, funcionario.Funcao, funcionario.PessoaId FROM funcionario INNER JOIN pessoa ON funcionario.PessoaId = Pessoa.Id WHERE (Pessoa.Nome LIKE ('%' || ? || '%'))", nome).ToList();
            }
            
            foreach (Funcionario element in list)
            {
                DB.GetChildren(element, false);
            }

            return list;
        }

        #endregion

        #region Produto

        public List<Produto> GetProdutos()
        {
            return UnitOfWork.ProdutoRepository.GetAll().ToList();
        }

        public void SaveProduto(Produto produto)
        {
            UnitOfWork.ProdutoRepository.AddOrUpdate(produto);
        }

        public List<Produto> FindProdutoByNome(string nome)
        {
            return UnitOfWork.ProdutoRepository.Find(a => a.Nome.Contains(nome)).ToList();
        }

        #endregion

        #region Servico

        public List<Servico> GetServicos()
        {
            return UnitOfWork.ServicoRepository.GetAll().ToList();
        }

        public void SaveServico(Servico servico)
        {
            UnitOfWork.ServicoRepository.AddOrUpdate(servico);
        }

        public List<Servico> FindServicoByNome(string nome)
        {
            return UnitOfWork.ServicoRepository.Find(a => a.Nome.Contains(nome)).ToList();
        }

        #endregion
    }
}
