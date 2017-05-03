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
            return UnitOfWork.PessoaRepository.GetAll().OrderBy(Pessoa => Pessoa.Nome).ToList();
        }

        public void SavePessoa(Pessoa pessoa)
        {
            UnitOfWork.PessoaRepository.AddOrUpdate(pessoa);
        }

        public List<Pessoa> FindPessoaByNome(string nome)
        {

            return UnitOfWork.PessoaRepository.Find(a => a.Nome.Contains(nome)).OrderBy(Pessoa => Pessoa.Nome).ToList();
        }

        public void DeletePessoa(Pessoa pessoa)
        {
            UnitOfWork.PessoaRepository.Delete(pessoa);
        }

        #endregion

        #region Despesa

        public List<Despesa> GetDespesas()
        {
            return UnitOfWork.DespesaRepository.GetAll().OrderByDescending(Despesa => Despesa.Id).ToList();
        }

        public void SaveDespesa(Despesa despesa)
        {
            UnitOfWork.DespesaRepository.AddOrUpdate(despesa);
        }

        public List<Despesa> FindDespesaByNome(string nome)
        {
            return UnitOfWork.DespesaRepository.Find(a => a.Nome.Contains(nome)).OrderByDescending(Despesa => Despesa.Id).ToList();
        }

        public void DeleteDespesa(Despesa despesa)
        {
            UnitOfWork.DespesaRepository.Delete(despesa);
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

        public void AtualizaEstoque(long? idProduto, int quantidadeEstoque)
        {
            
            DB.Query<Produto>("UPDATE Produto SET Quantidade = ? WHERE Id = ?", quantidadeEstoque, idProduto);
        }

        public List<Perda> FindPerdaByNome(string nome)
        {
            List<Perda> list = new List<Perda>();
            var elements = DB.Table<Perda>();
            if (nome == null || nome == "")
            {
                list = DB.Query<Perda>("SELECT perda.Id, perda.Nome, perda.Justificativa, perda.Registro FROM perda ORDER BY perda.Id DESC").ToList();
            }
            else
            {
                list = DB.Query<Perda>("SELECT perda.Id, perda.Nome, perda.Justificativa, perda.Registro FROM perda WHERE (perda.Nome LIKE ('%' || ? || '%')) ORDER BY perda.Id DESC", nome).ToList();
            }

            foreach (Perda element in list)
            {
                DB.GetChildren(element, false);
            }

            return list;
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
                list = DB.Query<Funcionario>("SELECT funcionario.Id, funcionario.Salario, funcionario.Funcao, funcionario.PessoaId FROM funcionario INNER JOIN pessoa ON funcionario.PessoaId = Pessoa.Id ORDER BY Pessoa.Nome").ToList();
            }
            else
            {
                list = DB.Query<Funcionario>("SELECT funcionario.Id, funcionario.Salario, funcionario.Funcao, funcionario.PessoaId FROM funcionario INNER JOIN pessoa ON funcionario.PessoaId = Pessoa.Id WHERE (Pessoa.Nome LIKE ('%' || ? || '%')) ORDER BY Pessoa.Nome", nome).ToList();
            }
            
            foreach (Funcionario element in list)
            {
                DB.GetChildren(element, false);
            }

            return list;
        }

        public void DeleteFuncionario(Funcionario funcionario)
        {
            UnitOfWork.FuncionarioRepository.Delete(funcionario);
        }

        #endregion

        #region Produto

        public List<Produto> GetProdutos()
        {
            return UnitOfWork.ProdutoRepository.GetAll().OrderBy(Produto => Produto.Nome).ToList();
        }

        public void SaveProduto(Produto produto)
        {
            UnitOfWork.ProdutoRepository.AddOrUpdate(produto);
        }

        public List<Produto> FindProdutoByNome(string nome)
        {
            return UnitOfWork.ProdutoRepository.Find(a => a.Nome.Contains(nome)).OrderBy(Produto => Produto.Nome).ToList();
        }

        public void DeleteProduto(Produto produto)
        {
            UnitOfWork.ProdutoRepository.Delete(produto);
        }

        #endregion

        #region Servico

        public List<Servico> GetServicos()
        {
            return UnitOfWork.ServicoRepository.GetAll().OrderBy(Servico => Servico.Nome).ToList();
        }

        public void SaveServico(Servico servico)
        {
            UnitOfWork.ServicoRepository.AddOrUpdate(servico);
        }

        public List<Servico> FindServicoByNome(string nome)
        {
            return UnitOfWork.ServicoRepository.Find(a => a.Nome.Contains(nome)).OrderBy(Servico => Servico.Nome).ToList();
        }

        public void DeleteServico(Servico servico)
        {
            UnitOfWork.ServicoRepository.Delete(servico);
        }

        #endregion

        #region Relatorios

        #region  RelatorioPessoaCliente

        public int RelatorioTotalClientes()
        {
            List<Pessoa> lista = new List<Pessoa>();
            lista = DB.Query<Pessoa>("SELECT Pessoa.Id FROM Pessoa");
            int totalClientes = lista.Count();

            return totalClientes;
        }

        public List<Pessoa> RelatorioClientesAdicionados(DateTime dataInicial, DateTime dataFinal)
        {
            List<Pessoa> lista = new List<Pessoa>();

            lista = DB.Query<Pessoa>("SELECT * FROM Pessoa");

            foreach (Pessoa element in lista)
            {
                if (DateTime.Compare(dataInicial, element.Registro) > 0 || DateTime.Compare(dataFinal, element.Registro) < 0)
                {
                    lista.Remove(element);
                }
            }

            return lista;

        }

        #endregion

        #region RelatorioDespesa

        #endregion

        #region RelatorioPerda

        #endregion

        #region RelatorioFuncionario

        #endregion

        #region RelatorioProduto

        public List<Produto> RelatorioProdutoSemEstoque(string nome)
        {
            List<Produto> list = new List<Produto>();
            if (nome == null || nome == "")
            {
                list = DB.Query<Produto>("SELECT Produto.Id, Produto.Nome, Produto.Marca, Produto.Preco FROM Produto WHERE Produto.Quantidade = 0").ToList();
            }else
            {
                list = DB.Query<Produto>("SELECT Produto.Id, Produto.Nome, Produto.Marca, Produto.Preco FROM Produto WHERE ((Produto.Quantidade = 0) AND (Produto.Nome LIKE ('%' || ? || '%')))", nome).ToList();
            }
            return list;
        }

        public decimal RelatorioValorTotalEstoque()
        {
            List<Produto> list = new List<Produto>();
            decimal total = 0m;

            list = DB.Query<Produto>("Produto.Preco, Produto.Quantidade FROM Produto WHERE Produto.Quantidade > 0").ToList();

            foreach (Produto element in list)
            {
                total = total + (element.Quantidade * element.Preco);
            }

            return total;
        }

        #endregion

        #region RelatorioServico

        #endregion

        #endregion
    }
}
