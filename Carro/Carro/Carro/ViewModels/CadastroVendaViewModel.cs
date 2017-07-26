using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Carro.Models;
using System.Collections.Generic;
using Carro.Repositories;
using Carro.Services;
using System.Threading.Tasks;
using Carro.Pages;
using System.Linq;

namespace Carro.ViewModels
{
    public class CadastroVendaViewModel : BaseViewModel
    {
        public CadastroVendaViewModel(INavigation navigation) : base(navigation)
        {
        }

        #region Propriedades

        ObservableCollection<Pessoa> _Pessoas = new ObservableCollection<Pessoa>();
        public ObservableCollection<Pessoa> Pessoas
        {
            get
            {
                return _Pessoas;
            }
            set
            {
                _Pessoas = value;
                SetPropertyChanged(nameof(Pessoas));
            }
        }

        Pessoa _pessoaSelecionada = new Pessoa();
        public Pessoa pessoaSelecionada
        {
            get
            {
                return _pessoaSelecionada;
            }
            set
            {
                _pessoaSelecionada = value;
                SetPropertyChanged(nameof(pessoaSelecionada));
            }
        }

        ObservableCollection<Funcionario> _Funcionarios = new ObservableCollection<Funcionario>();
        public ObservableCollection<Funcionario> Funcionarios
        {
            get
            {
                return _Funcionarios;
            }
            set
            {
                _Funcionarios = value;
                SetPropertyChanged(nameof(Funcionarios));
            }
        }

        ObservableCollection<FuncionarioServico> _FuncionariosSelecionados = new ObservableCollection<FuncionarioServico>();
        public ObservableCollection<FuncionarioServico> FuncionariosSelecionados
        {
            get
            {
                return _FuncionariosSelecionados;
            }
            set
            {
                _FuncionariosSelecionados = value;
                SetPropertyChanged(nameof(FuncionariosSelecionados));
            }
        }

        FuncionarioServico _funcionarioSelecionadoTemporario = new FuncionarioServico();
        public FuncionarioServico funcionarioSelecionadoTemporario
        {
            get
            {
                return _funcionarioSelecionadoTemporario;
            }
            set
            {
                _funcionarioSelecionadoTemporario = value;
                SetPropertyChanged(nameof(funcionarioSelecionadoTemporario));
            }
        }

        ObservableCollection<Produto> _Produtos = new ObservableCollection<Produto>();
        public ObservableCollection<Produto> Produtos
        {
            get
            {
                return _Produtos;
            }
            set
            {
                _Produtos = value;
                SetPropertyChanged(nameof(Produtos));
            }
        }

        ObservableCollection<OrdemVendaProduto> _ProdutosSelecionados = new ObservableCollection<OrdemVendaProduto>();
        public ObservableCollection<OrdemVendaProduto> ProdutosSelecionados
        {
            get
            {
                return _ProdutosSelecionados;
            }
            set
            {
                _ProdutosSelecionados = value;
                SetPropertyChanged(nameof(ProdutosSelecionados));
            }
        }

        OrdemVendaProduto _produtoSelecionadoTemporario = new OrdemVendaProduto();
        public OrdemVendaProduto produtoSelecionadoTemporario
        {
            get
            {
                return _produtoSelecionadoTemporario;
            }
            set
            {
                _produtoSelecionadoTemporario = value;
                SetPropertyChanged(nameof(produtoSelecionadoTemporario));
            }
        }

        ObservableCollection<Servico> _Servicos = new ObservableCollection<Servico>();
        public ObservableCollection<Servico> Servicos
        {
            get
            {
                return _Servicos;
            }
            set
            {
                _Servicos = value;
                SetPropertyChanged(nameof(Servicos));
            }
        }

        ObservableCollection<OrdemVendaServico> _ServicosSelecionados = new ObservableCollection<OrdemVendaServico>();
        public ObservableCollection<OrdemVendaServico> ServicosSelecionados
        {
            get
            {
                return _ServicosSelecionados;
            }
            set
            {
                _ServicosSelecionados = value;
                SetPropertyChanged(nameof(ServicosSelecionados));
            }
        }

        OrdemVendaServico _servicoSelecionadoTemporario = new OrdemVendaServico();
        public OrdemVendaServico servicoSelecionadoTemporario
        {
            get
            {
                return _servicoSelecionadoTemporario;
            }
            set
            {
                _servicoSelecionadoTemporario = value;
                SetPropertyChanged(nameof(servicoSelecionadoTemporario));
            }
        }

        decimal _ValorTotalProdutos = 0m;
        public decimal ValorTotalProdutos
        {
            get
            {
                return _ValorTotalProdutos;
            }
            set
            {
                _ValorTotalProdutos = value;
                SetPropertyChanged(nameof(ValorTotalProdutos));
            }
        }

        decimal _ValorTotalServicos = 0m;
        public decimal ValorTotalServicos
        {
            get
            {
                return _ValorTotalServicos;
            }
            set
            {
                _ValorTotalServicos = value;
                SetPropertyChanged(nameof(ValorTotalServicos));
            }
        }

        decimal _ValorTotal = 0m;
        public decimal ValorTotal
        {
            get
            {
                return _ValorTotal;
            }
            set
            {
                _ValorTotal = value;
                SetPropertyChanged(nameof(ValorTotal));
            }
        }

        decimal _DescontoProduto = 0m;
        public decimal DescontoProduto
        {
            get
            {
                return _DescontoProduto;
            }
            set
            {
                _DescontoProduto = value;
                SetPropertyChanged(nameof(DescontoProduto));
                _DescontoProdutoPorcentagem = AtualizaDescontoPorcentagemProduto();
                SetPropertyChanged(nameof(DescontoProdutoPorcentagem));
            }
        }

        decimal _DescontoProdutoPorcentagem = 0m;
        public decimal DescontoProdutoPorcentagem
        {
            get
            {
                return _DescontoProdutoPorcentagem;
            }
            set
            {
                _DescontoProdutoPorcentagem = value;
                SetPropertyChanged(nameof(DescontoProdutoPorcentagem));
                _DescontoProduto = AtualizaDescontoValorProduto();
                SetPropertyChanged(nameof(DescontoProduto));
            }
        }

        decimal _DescontoServico = 0m;
        public decimal DescontoServico
        {
            get
            {
                return _DescontoServico;
            }
            set
            {
                _DescontoServico = value;
                SetPropertyChanged(nameof(DescontoServico));
                _DescontoServicoPorcentagem = AtualizaDescontoPorcentagemServico();
                SetPropertyChanged(nameof(DescontoServicoPorcentagem));
            }
        }

        decimal _DescontoServicoPorcentagem = 0m;
        public decimal DescontoServicoPorcentagem
        {
            get
            {
                return _DescontoServicoPorcentagem;
            }
            set
            {
                _DescontoServicoPorcentagem = value;
                SetPropertyChanged(nameof(DescontoServicoPorcentagem));
                _DescontoServico = AtualizaDescontoValorServico();
                SetPropertyChanged(nameof(DescontoServico));
            }
        }

        string _SearchPessoa = string.Empty;
        public string SearchPessoa
        {
            get { return _SearchPessoa; }
            set
            {
                _SearchPessoa = value;
                var sqlite = DependencyService.Get<ISQLite>();
                Pessoas = new ObservableCollection<Pessoa>(new DataService(sqlite).FindPessoaByNome(_SearchPessoa));
            }
        }

        string _SearchFuncionario = string.Empty;
        public string SearchFuncionario
        {
            get { return _SearchFuncionario; }
            set
            {
                _SearchFuncionario = value;
                var sqlite = DependencyService.Get<ISQLite>();
                Funcionarios = new ObservableCollection<Funcionario>(new DataService(sqlite).FindFuncionarioByNome(_SearchFuncionario));
            }
        }

        string _SearchProduto = string.Empty;
        public string SearchProduto
        {
            get { return _SearchProduto; }
            set
            {
                _SearchProduto = value;
                var sqlite = DependencyService.Get<ISQLite>();
                Produtos = new ObservableCollection<Produto>(new DataService(sqlite).FindProdutoByNome(_SearchProduto));
            }
        }

        string _SearchServico = string.Empty;
        public string SearchServico
        {
            get { return _SearchServico; }
            set
            {
                _SearchProduto = value;
                var sqlite = DependencyService.Get<ISQLite>();
                Servicos = new ObservableCollection<Servico>(new DataService(sqlite).FindServicoByNome(_SearchServico));
            }
        }


        #endregion

        #region Commands

        public decimal AtualizaDescontoPorcentagemProduto()
        {
            decimal valorTotal;
            decimal porcentagem;

            valorTotal = produtoSelecionadoTemporario.QuantidadeVendida * produtoSelecionadoTemporario.Valor;
            if (valorTotal == 0)
            {
                valorTotal = produtoSelecionadoTemporario.Valor;
            }
            porcentagem = DescontoProduto / valorTotal * 100;

            return porcentagem;
        }

        public decimal AtualizaDescontoValorProduto()
        {
            decimal valorTotal;
            decimal valor;

            valorTotal = produtoSelecionadoTemporario.QuantidadeVendida * produtoSelecionadoTemporario.Valor;
            valor = valorTotal * DescontoProdutoPorcentagem / 100;

            return valor;
        }

        public decimal AtualizaDescontoPorcentagemServico()
        {
            decimal valorTotal;
            decimal porcentagem;

            valorTotal = servicoSelecionadoTemporario.QuantidadeVendida * servicoSelecionadoTemporario.Valor;
            if (valorTotal == 0)
            {
                valorTotal = servicoSelecionadoTemporario.Valor;
            }
            porcentagem = DescontoServico / valorTotal * 100;

            return porcentagem;
        }

        public decimal AtualizaDescontoValorServico()
        {
            decimal valorTotal;
            decimal valor;

            valorTotal = servicoSelecionadoTemporario.QuantidadeVendida * servicoSelecionadoTemporario.Valor;
            valor = valorTotal * DescontoServicoPorcentagem / 100;

            return valor;
        }

        public void AtualizaValorTotal()
        {
            foreach(OrdemVendaProduto produto in ProdutosSelecionados)
            {
                ValorTotalProdutos = ValorTotalProdutos + (produto.QuantidadeVendida * produto.Valor);
            }

            foreach (OrdemVendaServico servico in ServicosSelecionados)
            {
                ValorTotalServicos = ValorTotalServicos + (servico.QuantidadeVendida * servico.Valor);
            }

            ValorTotal = ValorTotalProdutos + ValorTotalServicos;
        }

        Command _CadastroVendaVoltaCommand;
        public Command CadastroVendaVoltaCommand
        {
            get { return _CadastroVendaVoltaCommand ?? (_CadastroVendaVoltaCommand = new Command(async () => await ExecuteCadastroVendaVoltaCommand())); }
        }

        async Task ExecuteCadastroVendaVoltaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PopAsync();
                IsBusy = false;
            }
        }

        Command _CadastroVendaProdutoCommand;
        public Command CadastroVendaProdutoCommand
        {
            get { return _CadastroVendaProdutoCommand ?? (_CadastroVendaProdutoCommand = new Command(async () => await ExecuteCadastroVendaProdutoCommand())); }
        }

        async Task ExecuteCadastroVendaProdutoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroVendaProdutoPage(this));
                IsBusy = false;
            }
        }

        Command _CadastroVendaServicoCommand;
        public Command CadastroVendaServicoCommand
        {
            get { return _CadastroVendaServicoCommand ?? (_CadastroVendaServicoCommand = new Command(async () => await ExecuteCadastroVendaServicoCommand())); }
        }

        async Task ExecuteCadastroVendaServicoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroVendaServicoPage(this));
                IsBusy = false;
            }
        }

        Command _CadastroVendaConclucaoCommand;
        public Command CadastroVendaConclucaoCommand
        {
            get { return _CadastroVendaConclucaoCommand ?? (_CadastroVendaConclucaoCommand = new Command(async () => await ExecuteCadastroVendaConclucaoCommand())); }
        }

        async Task ExecuteCadastroVendaConclucaoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroVendaConclusaoPage(this));
                IsBusy = false;
            }
        }

        Command _SalvarPreVendaCommand;
        public Command SalvarPreVendaCommand
        {
            get { return _SalvarPreVendaCommand ?? (_SalvarPreVendaCommand = new Command(async () => await ExecutePreSalvarVendaCommand())); }
        }

        async Task ExecutePreSalvarVendaCommand()
        {
            if (!IsBusy)
            {
                if (!IsBusy)
                {
                    IsBusy = true;

                    var sqlite = DependencyService.Get<ISQLite>();
                    using (var scope = new TransactionScope(sqlite))
                    {
                        var service = new DataService(sqlite);
                        DateTime data = DateTime.UtcNow;

                        foreach (OrdemVendaProduto vendido in ProdutosSelecionados)
                        {
                            if (vendido.QuantidadeVendida > vendido.Quantidade)
                            {
                                service.AtualizaEstoque(vendido.IdProduto, 0);
                            }
                            else
                            {
                                service.AtualizaEstoque(vendido.IdProduto, (vendido.Quantidade - vendido.QuantidadeVendida));
                            }
                        }

                        service.SaveOrdemVenda(new OrdemVenda { eVenda = false, IdCliente = pessoaSelecionada.Id, Pessoa = pessoaSelecionada, PrazoInicial = 0, NumeroParcelas = 0, ParcelasPagas = 0, Valor = ValorTotal, Registro = data, FuncionarioServicos = FuncionariosSelecionados.ToList<FuncionarioServico>(), OrdemVendaProdutos = ProdutosSelecionados.ToList<OrdemVendaProduto>(), OrdemVendaServicos = ServicosSelecionados.ToList<OrdemVendaServico>()});

                        scope.Complete();
                    }
                    await Navigation.PopToRootAsync();
                    IsBusy = false;
                }
            }
        }

        Command _ListaClienteCommand;
        public Command ListaClienteCommand
        {
            get { return _ListaClienteCommand ?? (_ListaClienteCommand = new Command(async () => await ExecuteListaClienteCommand())); }
        }

        async Task ExecuteListaClienteCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroVendaClienteListaPage(this));
                IsBusy = false;
            }
        }

        Command _ListaFuncionarioCommand;
        public Command ListaFuncionarioCommand
        {
            get { return _ListaFuncionarioCommand ?? (_ListaFuncionarioCommand = new Command(async () => await ExecuteListaFuncionarioCommand())); }
        }

        async Task ExecuteListaFuncionarioCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroVendaFuncionarioListaPage(this));
                IsBusy = false;
            }
        }

        Command _ListaProdutoCommand;
        public Command ListaProdutoCommand
        {
            get { return _ListaProdutoCommand ?? (_ListaProdutoCommand = new Command(async () => await ExecuteListaProdutoCommand())); }
        }

        async Task ExecuteListaProdutoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroVendaProdutoListaPage(this));
                IsBusy = false;
            }
        }

        Command _ListaServicoCommand;
        public Command ListaServicoCommand
        {
            get { return _ListaServicoCommand ?? (_ListaServicoCommand = new Command(async () => await ExecuteListaServicoCommand())); }
        }

        async Task ExecuteListaServicoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroVendaServicoListaPage(this));
                IsBusy = false;
            }
        }


        Command _AdicionaClienteCommand;
        public Command AdicionaClienteCommand
        {
            get { return _AdicionaClienteCommand ?? (_AdicionaClienteCommand = new Command<Pessoa>(async (qq) => await ExecuteAdicionaClienteCommand(qq))); }
        }

        async Task ExecuteAdicionaClienteCommand(Pessoa value)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                pessoaSelecionada = value;
                await Navigation.PopAsync();
                IsBusy = false;
            }
        }

        Command _AdicionaFuncionarioCommand;
        public Command AdicionaFuncionarioCommand
        {
            get { return _AdicionaFuncionarioCommand ?? (_AdicionaFuncionarioCommand = new Command<Funcionario>(async (qq) => await ExecuteAdicionaFuncionarioCommand(qq))); }
        }

        async Task ExecuteAdicionaFuncionarioCommand(Funcionario value)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                funcionarioSelecionadoTemporario.IdFuncionario = value.Id;
                funcionarioSelecionadoTemporario.Funcionario = value;
                FuncionariosSelecionados.Add(funcionarioSelecionadoTemporario);
                funcionarioSelecionadoTemporario = new FuncionarioServico();
                await Navigation.PopAsync();
                IsBusy = false;
            }
        }

        Command _RemoveFuncionarioCommand;
        public Command RemoveFuncionarioCommand
        {
            get { return _RemoveFuncionarioCommand ?? (_RemoveFuncionarioCommand = new Command<FuncionarioServico>((qq) => ExecuteRemoveFuncionarioCommand(qq))); }
        }

        void ExecuteRemoveFuncionarioCommand(FuncionarioServico qq)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                FuncionariosSelecionados.Remove(qq);
                IsBusy = false;
            }
        }

        Command _AdicionaProdutoCommand;
        public Command AdicionaProdutoCommand
        {
            get { return _AdicionaProdutoCommand ?? (_AdicionaProdutoCommand = new Command<Produto>(async (qq) => await ExecuteAdicionaProdutoCommand(qq))); }
        }

        async Task ExecuteAdicionaProdutoCommand(Produto value)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                produtoSelecionadoTemporario.IdProduto = value.Id;
                produtoSelecionadoTemporario.Local = value.Local;
                produtoSelecionadoTemporario.Marca = value.Marca;
                produtoSelecionadoTemporario.Nome = value.Nome;
                produtoSelecionadoTemporario.Quantidade = value.Quantidade;
                produtoSelecionadoTemporario.Valor = value.Preco;
                produtoSelecionadoTemporario.Descricao = value.Descricao;
                await Navigation.PopAsync();
                await Navigation.PushAsync(new CadastroVendaProdutoQuantidadePage(this));
                IsBusy = false;
            }
        }

        Command _RemoveProdutoCommand;
        public Command RemoveProdutoCommand
        {
            get { return _RemoveProdutoCommand ?? (_RemoveProdutoCommand = new Command<OrdemVendaProduto>((qq) => ExecuteRemoveProdutoCommand(qq))); }
        }

        void ExecuteRemoveProdutoCommand(OrdemVendaProduto qq)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                ProdutosSelecionados.Remove(qq);
                ValorTotalProdutos = 0m;
                ValorTotalServicos = 0m;
                AtualizaValorTotal();
                IsBusy = false;
            }
        }

        Command _AdicionaServicoCommand;
        public Command AdicionaServicoCommand
        {
            get { return _AdicionaServicoCommand ?? (_AdicionaServicoCommand = new Command<Servico>(async (qq) => await ExecuteAdicionaServicoCommand(qq))); }
        }

        async Task ExecuteAdicionaServicoCommand(Servico value)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                servicoSelecionadoTemporario.IdServico = value.Id;
                servicoSelecionadoTemporario.Nome = value.Nome;
                servicoSelecionadoTemporario.Tempo = value.Tempo;
                servicoSelecionadoTemporario.Valor = value.Preco;
                servicoSelecionadoTemporario.Descricao = value.Descricao;
                await Navigation.PopAsync();
                await Navigation.PushAsync(new CadastroVendaServicoQuantidadePage(this));
                IsBusy = false;
            }
        }

        Command _RemoveServicoCommand;
        public Command RemoveServicoCommand
        {
            get { return _RemoveServicoCommand ?? (_RemoveServicoCommand = new Command<OrdemVendaServico>((qq) => ExecuteRemoveServicoCommand(qq))); }
        }

        void ExecuteRemoveServicoCommand(OrdemVendaServico qq)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                ServicosSelecionados.Remove(qq);
                ValorTotalProdutos = 0m;
                ValorTotalServicos = 0m;
                AtualizaValorTotal();
                IsBusy = false;
            }
        }

        Command _SalvaVendaProdutoQuantidadeCommand;
        public Command SalvaVendaProdutoQuantidadeCommand
        {
            get { return _SalvaVendaProdutoQuantidadeCommand ?? (_SalvaVendaProdutoQuantidadeCommand = new Command(async () => await ExecuteSalvaVendaProdutoQuantidadeCommand())); }
        }

        async Task ExecuteSalvaVendaProdutoQuantidadeCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                if(produtoSelecionadoTemporario.QuantidadeVendida > 0)
                {
                    ProdutosSelecionados.Add(produtoSelecionadoTemporario);
                    produtoSelecionadoTemporario = new OrdemVendaProduto();
                    ValorTotalProdutos = 0m;
                    ValorTotalServicos = 0m;
                    AtualizaValorTotal();
                }
                await Navigation.PopAsync();
                IsBusy = false;
            }
        }

        Command _SalvaVendaServicoQuantidadeCommand;
        public Command SalvaVendaServicoQuantidadeCommand
        {
            get { return _SalvaVendaServicoQuantidadeCommand ?? (_SalvaVendaServicoQuantidadeCommand = new Command(async () => await ExecuteSalvaVendaServicoQuantidadeCommand())); }
        }

        async Task ExecuteSalvaVendaServicoQuantidadeCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                if(servicoSelecionadoTemporario.QuantidadeVendida > 0)
                {
                    ServicosSelecionados.Add(servicoSelecionadoTemporario);
                    servicoSelecionadoTemporario = new OrdemVendaServico();
                    ValorTotalProdutos = 0m;
                    ValorTotalServicos = 0m;
                    AtualizaValorTotal();
                }
                await Navigation.PopAsync();
                IsBusy = false;
            }
        }

        #endregion
    }
}
