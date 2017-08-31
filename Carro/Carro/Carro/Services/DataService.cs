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

        #region OrdemVenda

        public void SaveOrdemVenda(OrdemVenda ordemvenda)
        {
            UnitOfWork.OrdemVendaRepository.AddOrUpdate(ordemvenda);
        }

        public List<OrdemVenda> FindVendaByNome(string nome, bool eVenda)
        {
            List<OrdemVenda> list = new List<OrdemVenda>();
            if (nome == null || nome == "")
            {
                list = DB.Query<OrdemVenda>("SELECT * FROM OrdemVenda WHERE eVenda = ? ORDER BY Registro", eVenda).ToList();
            }
            else
            {
                list = DB.Query<OrdemVenda>("SELECT * FROM OrdemVenda INNER JOIN Pessoa ON OrdemVenda.IdCliente = Pessoa.Id WHERE ((Pessoa.Nome LIKE ('%' || ? || '%')) AND eVenda = ?) ORDER BY Registro", nome, eVenda).ToList();
            }

            foreach (OrdemVenda element in list)
            {
                DB.GetChildren(element, true);
            }

            return list;
        }

        public void TransformaEmVenda(long? id)
        {

            DB.Query<OrdemVenda>("UPDATE OrdemVenda SET eVenda = 1 WHERE OrdemVenda.Id = ?", id);

        }

        public void PagaParcela(long? IdOrdemVenda, long? IdParcela)
        {
            DB.Query<OrdemVenda>("UPDATE OrdemVendaParcela SET Pago = 1 WHERE OrdemVendaParcela.IdOrdemVenda = ? AND OrdemVendaParcela.Id = ?", IdOrdemVenda, IdParcela);
        }

        public List<OrdemVendaParcela> BuscaParcelas(long? IdOrdemVenda)
        {
            List<OrdemVendaParcela> list = new List<OrdemVendaParcela>();

            list = DB.Query<OrdemVendaParcela>("SELECT * FROM OrdemVendaParcela WHERE OrdemVendaParcela.IdOrdemVenda = ? ", IdOrdemVenda);

            return list;
        }

        #endregion

        #region Relatorios

        #region RelatorioSaldo


        public decimal RelatorioSaldoVendasRecebidas(DateTime dataInicial, DateTime dataFinal)
        {
            decimal vendasRecebidas = 0;
            List<OrdemVendaParcela> listaOrdemVenda = new List<OrdemVendaParcela>();


            listaOrdemVenda = DB.Query<OrdemVendaParcela>("SELECT * FROM OrdemVendaParcela");

            foreach (OrdemVendaParcela element in listaOrdemVenda)
            {
                DB.GetChildren(element, true);
            }

            foreach (OrdemVendaParcela element in listaOrdemVenda.ToList())
            {
                if (element.OrdemVenda.Registro < dataInicial || element.OrdemVenda.Registro > dataFinal)
                {
                    listaOrdemVenda.Remove(element);
                }

                if (element.OrdemVenda.eVenda == false)
                {
                    listaOrdemVenda.Remove(element);
                }

                if (element.Pago == false)
                {
                    listaOrdemVenda.Remove(element);
                }
            }

            foreach (OrdemVendaParcela element in listaOrdemVenda.ToList())
            {
                if (element.OrdemVenda.FormaPagamento == 1)
                {
                    vendasRecebidas = vendasRecebidas + element.OrdemVenda.Valor;
                }
                if (element.OrdemVenda.FormaPagamento == 2)
                {
                    vendasRecebidas = vendasRecebidas + element.ValorParcela;
                }

            }

            return vendasRecebidas;
        }

        public decimal RelatorioSaldoDespesas(DateTime dataInicial, DateTime dataFinal)
        {
            decimal despesas = 0;
            List<Despesa> listaDespesa = new List<Despesa>();


            listaDespesa = DB.Query<Despesa>("SELECT * FROM Despesa WHERE Registro >= ? AND Registro <= ?", dataInicial.Ticks, dataFinal.Ticks);

            foreach (Despesa element in listaDespesa)
            {
                despesas = despesas + element.Valor;
            }


            return despesas;
        }

        public decimal RelatorioSaldoPerdas(DateTime dataInicial, DateTime dataFinal)
        {
            decimal perdas = 0;
            List<PerdaProduto> listaPerda = new List<PerdaProduto>();

            listaPerda = DB.Query<PerdaProduto>("SELECT * FROM PerdaProduto");

            foreach (PerdaProduto element in listaPerda)
            {
                DB.GetChildren(element, true);
            }

            foreach (PerdaProduto element in listaPerda.ToList())
            {
                if (element.Perda.Registro < dataInicial || element.Perda.Registro > dataFinal)
                {
                    listaPerda.Remove(element);
                }
            }

            foreach (PerdaProduto element in listaPerda)
            {
                perdas = perdas + (element.QuantidadePerdida * element.Preco);
            }

            return perdas;
        }

        #endregion

        #region RelatorioFinalVenda

        #endregion

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

            lista = DB.Query<Pessoa>("SELECT * FROM Pessoa WHERE Registro >= ? AND Registro <= ?", dataInicial.Ticks, dataFinal.Ticks);

            return lista;

        }

        public List<OrdemVenda> RelatorioClientesCompraramQuantidade(DateTime dataInicial, DateTime dataFinal)
        {
            List<OrdemVenda> lista = new List<OrdemVenda>();

            lista = DB.Query<OrdemVenda>("SELECT IdCliente, Count(*) AS Valor FROM OrdemVenda WHERE Registro >= ? AND Registro <= ? AND eVenda = 1 GROUP BY IdCliente ORDER BY Valor DESC", dataInicial.Ticks, dataFinal.Ticks);

            foreach (OrdemVenda element in lista)
            {
                DB.GetChildren(element, true);
            }

            return lista;

        }

        public List<OrdemVenda> RelatorioClientesCompraramValor(DateTime dataInicial, DateTime dataFinal)
        {
            List<OrdemVenda> lista = new List<OrdemVenda>();

            lista = DB.Query<OrdemVenda>("SELECT IdCliente, SUM(Valor) AS Valor FROM OrdemVenda WHERE Registro >= ? AND Registro <= ? AND eVenda = 1 GROUP BY IdCliente ORDER BY Valor DESC", dataInicial.Ticks, dataFinal.Ticks);

            foreach (OrdemVenda element in lista)
            {
                DB.GetChildren(element, true);
            }

            return lista;

        }

        #endregion

        #region RelatorioDespesa

        public List<Despesa> RelatorioDespesas(DateTime dataInicial, DateTime dataFinal, int categoria)
        {
            List<Despesa> lista = new List<Despesa>();
            if (categoria == 0)
            {
                lista = DB.Query<Despesa>("SELECT * FROM Despesa WHERE Registro >= ? AND Registro <= ?", dataInicial.Ticks, dataFinal.Ticks);
            }
            else
            {
                lista = DB.Query<Despesa>("SELECT * FROM Despesa WHERE Registro >= ? AND Registro <= ? AND Categoria = ?", dataInicial.Ticks, dataFinal.Ticks, categoria);
            }

            return lista;

        }

        #endregion

        #region RelatorioPerda

        public decimal RelatorioPerdas(DateTime dataInicial, DateTime dataFinal)
        {

            List<PerdaProduto> lista = new List<PerdaProduto>();
            decimal ValorTotalPerdas = 0;

            lista = DB.Query<PerdaProduto>("SELECT * FROM PerdaProduto");

            foreach (PerdaProduto element in lista)
            {
                DB.GetChildren(element, true);
            }

            foreach (PerdaProduto element in lista.ToList())
            {
                if (element.Perda.Registro < dataInicial || element.Perda.Registro > dataFinal)
                {
                    lista.Remove(element);
                }
            }

            foreach (PerdaProduto element in lista.ToList())
            {
                ValorTotalPerdas = ValorTotalPerdas + (element.QuantidadePerdida * element.Preco);
            }

            return ValorTotalPerdas;
        }

        #endregion

        #region RelatorioFuncionario

        public List<FuncionarioServico> RelatorioFuncionarioVendaQuantidade(DateTime dataInicial, DateTime dataFinal)
        {
            List<FuncionarioServico> lista = new List<FuncionarioServico>();

            lista = DB.Query<FuncionarioServico>("SELECT IdFuncionario, IdOrdemVenda, Count(*) AS Valor FROM FuncionarioServico GROUP BY IdFuncionario ORDER BY Valor DESC");

            foreach (FuncionarioServico element in lista)
            {
                DB.GetChildren(element, true);
            }

            foreach (FuncionarioServico element in lista.ToList())
            {
                if (element.OrdemVenda.Registro < dataInicial || element.OrdemVenda.Registro > dataFinal)
                {
                    lista.Remove(element);
                }

                if (element.OrdemVenda.eVenda == false)
                {
                    lista.Remove(element);
                }
            }

            return lista;

        }

        public List<FuncionarioServico> RelatorioFuncionarioVendaValor(DateTime dataInicial, DateTime dataFinal)
        {
            List<FuncionarioServico> lista = new List<FuncionarioServico>();

            lista = DB.Query<FuncionarioServico>("SELECT FuncionarioServico.IdFuncionario, FuncionarioServico.IdOrdemVenda, SUM(OrdemVenda.Valor) AS Valor FROM FuncionarioServico INNER JOIN OrdemVenda ON FuncionarioServico.IdOrdemVenda = OrdemVenda.Id GROUP BY FuncionarioServico.IdFuncionario ORDER BY FuncionarioServico.Valor DESC");

            foreach (FuncionarioServico element in lista)
            {
                DB.GetChildren(element, true);
            }

            foreach (FuncionarioServico element in lista.ToList())
            {
                if (element.OrdemVenda.Registro < dataInicial || element.OrdemVenda.Registro > dataFinal)
                {
                    lista.Remove(element);
                }

                if (element.OrdemVenda.eVenda == false)
                {
                    lista.Remove(element);
                }
            }

            return lista;

        }

        #endregion

        #region RelatorioProduto

        public List<Produto> RelatorioProdutoSemEstoque(string nome)
        {
            List<Produto> list = new List<Produto>();
            if (nome == null || nome == "")
            {
                list = DB.Query<Produto>("SELECT Produto.Id, Produto.Nome, Produto.Marca, Produto.Preco FROM Produto WHERE Produto.Quantidade = 0").ToList();
            }
            else
            {
                list = DB.Query<Produto>("SELECT Produto.Id, Produto.Nome, Produto.Marca, Produto.Preco FROM Produto WHERE ((Produto.Quantidade = 0) AND (Produto.Nome LIKE ('%' || ? || '%')))", nome).ToList();
            }
            return list;
        }

        public decimal RelatorioValorTotalEstoque()
        {
            List<Produto> list = new List<Produto>();
            decimal total = 0m;

            list = DB.Query<Produto>("SELECT Produto.Preco, Produto.Quantidade FROM Produto WHERE Produto.Quantidade > 0").ToList();

            foreach (Produto element in list)
            {
                total = total + (element.Quantidade * element.Preco);
            }

            return total;
        }

        public List<OrdemVendaProduto> RelatorioProdutosMaisVendidos(DateTime dataInicial, DateTime dataFinal)
        {

            List<OrdemVendaProduto> lista = new List<OrdemVendaProduto>();

            lista = DB.Query<OrdemVendaProduto>("SELECT IdProduto, IdOrdemVenda, Nome, Marca, SUM(QuantidadeVendida) AS QuantidadeVendida FROM OrdemVendaProduto GROUP BY IdProduto ORDER BY QuantidadeVendida DESC");

            foreach (OrdemVendaProduto element in lista)
            {
                DB.GetChildren(element, true);
            }

            foreach (OrdemVendaProduto element in lista.ToList())
            {
                if (element.OrdemVenda.Registro < dataInicial || element.OrdemVenda.Registro > dataFinal)
                {
                    lista.Remove(element);
                }

                if (element.OrdemVenda.eVenda == false)
                {
                    lista.Remove(element);
                }
            }

            return lista;
        }

        #endregion

        #region RelatorioServico

        public List<OrdemVendaServico> RelatorioServicosMaisVendidos(DateTime dataInicial, DateTime dataFinal)
        {

            List<OrdemVendaServico> lista = new List<OrdemVendaServico>();

            lista = DB.Query<OrdemVendaServico>("SELECT IdServico, IdOrdemVenda, Nome, Tempo, SUM(QuantidadeVendida) AS QuantidadeVendida FROM OrdemVendaServico GROUP BY IdServico ORDER BY QuantidadeVendida DESC");

            foreach (OrdemVendaServico element in lista)
            {
                DB.GetChildren(element, true);
            }

            foreach (OrdemVendaServico element in lista.ToList())
            {
                if (element.OrdemVenda.Registro < dataInicial || element.OrdemVenda.Registro > dataFinal)
                {
                    lista.Remove(element);
                }

                if (element.OrdemVenda.eVenda == false)
                {
                    lista.Remove(element);
                }
            }

            return lista;
        }

        #endregion

        #endregion
    }
}
