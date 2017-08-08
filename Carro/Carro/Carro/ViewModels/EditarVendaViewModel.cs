using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Carro.Models;
using System.Collections.Generic;
using Carro.Repositories;
using Carro.Services;
using System.Threading.Tasks;
using Carro.Pages;
using Carro.Pages.Help;
using System.Linq;

namespace Carro.ViewModels
{
    public class EditarVendaViewModel : BaseViewModel
    {
        public EditarVendaViewModel(INavigation navigation, OrdemVenda value) : base(navigation)
        {
            idEntry = value.Id;
            pessoaSelecionada = value.Pessoa;
            Parcelas = value.Parcelas;
            Entrada = value.Parcelas;
            FormaPagamento = value.FormaPagamento;
            ValorTotalComDesconto = value.Valor;
            DescontoGeral = value.DescontoTotal;
            FuncionariosSelecionados = new ObservableCollection<FuncionarioServico>(value.FuncionarioServicos);
            ProdutosSelecionados = new ObservableCollection<OrdemVendaProduto>(value.OrdemVendaProdutos);
            ServicosSelecionados = new ObservableCollection<OrdemVendaServico>(value.OrdemVendaServicos);
            ValorTotal = value.Valor;    
        }

        #region Propriedades

        long? _idEntry = 0;
        public long? idEntry
        {
            get
            {
                return _idEntry;
            }
            set
            {
                _idEntry = value;
                SetPropertyChanged(nameof(idEntry));
            }
        }

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

        decimal _ValorTotalComDesconto = 0m;
        public decimal ValorTotalComDesconto
        {
            get
            {
                return _ValorTotalComDesconto;
            }
            set
            {
                _ValorTotalComDesconto = value;
                SetPropertyChanged(nameof(ValorTotalComDesconto));
            }
        }

        decimal _DescontoTotalIndividual = 0m;
        public decimal DescontoTotalIndividual
        {
            get
            {
                return _DescontoTotalIndividual;
            }
            set
            {
                _DescontoTotalIndividual = value;
                SetPropertyChanged(nameof(DescontoTotalIndividual));
            }
        }

        decimal _DescontoGeral = 0m;
        public decimal DescontoGeral
        {
            get
            {
                return _DescontoGeral;
            }
            set
            {
                _DescontoGeral = value;
                SetPropertyChanged(nameof(DescontoGeral));
                _DescontoGeralPorcentagem = AtualizaDescontoPorcentagemGeral();
                SetPropertyChanged(nameof(DescontoGeralPorcentagem));
                AtualizaValorTotalComDesconto();
            }
        }

        decimal _DescontoGeralPorcentagem = 0m;
        public decimal DescontoGeralPorcentagem
        {
            get
            {
                return _DescontoGeralPorcentagem;
            }
            set
            {
                _DescontoGeralPorcentagem = value;
                SetPropertyChanged(nameof(DescontoGeralPorcentagem));
                _DescontoGeral = AtualizaDescontoValorGeral();
                SetPropertyChanged(nameof(DescontoGeral));
                AtualizaValorTotalComDesconto();
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

        int _FormaPagamento = 0;
        public int FormaPagamento
        {
            get
            {
                return _FormaPagamento;
            }
            set
            {
                _FormaPagamento = value;
                SetPropertyChanged(nameof(FormaPagamento));
                //0 = Selecione a forma de pagamento (Invalido)
                //1 = A vista
                //2 = A prazo
                if (FormaPagamento == 0)
                {
                    FormaPagamentoInvalido = true;
                    Parcelas = 0;
                    ParcelasInvalido = true;
                    ParcelasIsEnabled = true;
                    Entrada = 0;
                    EntradaInvalido = true;
                    EntradaIsEnabled = true;
                }
                else
                {
                    if (FormaPagamento == 1)
                    {
                        FormaPagamentoInvalido = false;
                        Parcelas = 0;
                        ParcelasInvalido = false;
                        ParcelasIsEnabled = false;
                        Entrada = 0;
                        EntradaInvalido = false;
                        EntradaIsEnabled = false;

                    }
                    else
                    {
                        FormaPagamentoInvalido = false;
                        ParcelasInvalido = true;
                        ParcelasIsEnabled = true;
                        EntradaInvalido = true;
                        EntradaIsEnabled = true;
                    }
                }
            }
        }

        bool _FormaPagamentoInvalido = true;
        public bool FormaPagamentoInvalido
        {
            get
            {
                return _FormaPagamentoInvalido;
            }
            set
            {
                _FormaPagamentoInvalido = value;
                SetPropertyChanged(nameof(FormaPagamentoInvalido));
            }
        }

        int _Parcelas = 0;
        public int Parcelas
        {
            get
            {
                return _Parcelas;
            }
            set
            {
                _Parcelas = value;
                SetPropertyChanged(nameof(Parcelas));
                //0 = Selecione o numero de parcelas (Invalido)
                //1 = 1x
                //2 = 2x
                //3 = 3x
                //4 = 4x
                //5 = 5x
                //6 = 6x
                //9 = 9x
                //12 = 12x
                if (Parcelas == 0)
                {
                    ParcelasInvalido = true;
                    if (FormaPagamento == 1)
                    {
                        ParcelasInvalido = false;
                    }
                }
                else
                {
                    ParcelasInvalido = false;
                }
            }
        }

        bool _ParcelasInvalido = true;
        public bool ParcelasInvalido
        {
            get
            {
                return _ParcelasInvalido;
            }
            set
            {
                _ParcelasInvalido = value;
                SetPropertyChanged(nameof(ParcelasInvalido));
            }
        }

        bool _ParcelasIsEnabled = true;
        public bool ParcelasIsEnabled
        {
            get
            {
                return _ParcelasIsEnabled;
            }
            set
            {
                _ParcelasIsEnabled = value;
                SetPropertyChanged(nameof(ParcelasIsEnabled));
            }
        }

        int _Entrada = 0;
        public int Entrada
        {
            get
            {
                return _Entrada;
            }
            set
            {
                _Entrada = value;
                SetPropertyChanged(nameof(Entrada));
                //0 = Selecione a entrada (Invalido)
                //1 = A vista
                //2 = 30 dias
                //3 = 60 dias
                //4 = 90 dias
                if (Entrada == 0)
                {
                    EntradaInvalido = true;
                    if (FormaPagamento == 1)
                    {
                        EntradaInvalido = false;
                    }
                }
                else
                {
                    EntradaInvalido = false;
                }

            }
        }

        bool _EntradaInvalido = true;
        public bool EntradaInvalido
        {
            get
            {
                return _EntradaInvalido;
            }
            set
            {
                _EntradaInvalido = value;
                SetPropertyChanged(nameof(EntradaInvalido));
            }
        }

        bool _EntradaIsEnabled = true;
        public bool EntradaIsEnabled
        {
            get
            {
                return _EntradaIsEnabled;
            }
            set
            {
                _EntradaIsEnabled = value;
                SetPropertyChanged(nameof(EntradaIsEnabled));
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
                porcentagem = 0;
            }
            else
            {
                porcentagem = DescontoProduto / valorTotal * 100;
            }


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
                porcentagem = 0;
            }
            else
            {
                porcentagem = DescontoServico / valorTotal * 100;
            }


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

        public decimal AtualizaDescontoPorcentagemGeral()
        {
            decimal valorTotal;
            decimal porcentagem;

            valorTotal = ValorTotal;
            if (valorTotal == 0)
            {
                porcentagem = 0;
            }
            else
            {
                porcentagem = DescontoGeral / valorTotal * 100;
            }

            return porcentagem;
        }

        public decimal AtualizaDescontoValorGeral()
        {
            decimal valorTotal;
            decimal valor;

            valorTotal = ValorTotal;
            valor = valorTotal * DescontoGeralPorcentagem / 100;

            return valor;
        }

        public void AtualizaValorTotal()
        {
            foreach (OrdemVendaProduto produto in ProdutosSelecionados)
            {
                ValorTotalProdutos = ValorTotalProdutos + (produto.QuantidadeVendida * produto.Valor);
            }

            foreach (OrdemVendaServico servico in ServicosSelecionados)
            {
                ValorTotalServicos = ValorTotalServicos + (servico.QuantidadeVendida * servico.Valor);
            }

            ValorTotal = ValorTotalProdutos + ValorTotalServicos;
        }

        public void AtualizaDescontoTotalIndividual()
        {
            decimal desconto = 0m;
            foreach (OrdemVendaProduto produto in ProdutosSelecionados)
            {
                desconto = desconto + produto.Desconto;
            }

            foreach (OrdemVendaServico servico in ServicosSelecionados)
            {
                desconto = desconto + servico.Desconto;
            }

            DescontoTotalIndividual = desconto;
        }

        public void AtualizaValorTotalComDesconto()
        {
            ValorTotalComDesconto = ValorTotal - DescontoTotalIndividual - DescontoGeral;
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
                await Navigation.PushAsync(new EditarVendaProdutoPage(this));
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
                await Navigation.PushAsync(new EditarVendaServicoPage(this));
                IsBusy = false;
            }
        }

        Command _CadastroVendaConclusaoCommand;
        public Command CadastroVendaConclusaoCommand
        {
            get { return _CadastroVendaConclusaoCommand ?? (_CadastroVendaConclusaoCommand = new Command(async () => await ExecuteCadastroVendaConclusaoCommand())); }
        }

        async Task ExecuteCadastroVendaConclusaoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                AtualizaDescontoTotalIndividual();
                AtualizaValorTotalComDesconto();
                await Navigation.PushAsync(new EditarVendaConclusaoPage(this));
                IsBusy = false;
            }
        }

        Command _SalvarPreVendaCommand;
        public Command SalvarPreVendaCommand
        {
            get { return _SalvarPreVendaCommand ?? (_SalvarPreVendaCommand = new Command(async () => await ExecuteSalvarPreVendaCommand())); }
        }

        async Task ExecuteSalvarPreVendaCommand()
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

                        service.SaveOrdemVenda(new OrdemVenda { eVenda = false, IdCliente = pessoaSelecionada.Id, Pessoa = pessoaSelecionada, FormaPagamento = FormaPagamento, Parcelas = Parcelas, Valor = ValorTotalComDesconto, DescontoTotal = DescontoGeral, Registro = data, FuncionarioServicos = FuncionariosSelecionados.ToList<FuncionarioServico>(), OrdemVendaProdutos = ProdutosSelecionados.ToList<OrdemVendaProduto>(), OrdemVendaServicos = ServicosSelecionados.ToList<OrdemVendaServico>() });

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
                await Navigation.PushAsync(new EditarVendaClienteListaPage(this));
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
                await Navigation.PushAsync(new EditarVendaFuncionarioListaPage(this));
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
                await Navigation.PushAsync(new EditarVendaProdutoListaPage(this));
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
                await Navigation.PushAsync(new EditarVendaServicoListaPage(this));
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
                await Navigation.PushAsync(new EditarVendaProdutoQuantidadePage(this));
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
                await Navigation.PushAsync(new EditarVendaServicoQuantidadePage(this));
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
                if (produtoSelecionadoTemporario.QuantidadeVendida > 0)
                {
                    produtoSelecionadoTemporario.Desconto = DescontoProduto;
                    ProdutosSelecionados.Add(produtoSelecionadoTemporario);
                    produtoSelecionadoTemporario = new OrdemVendaProduto();
                    ValorTotalProdutos = 0m;
                    ValorTotalServicos = 0m;
                    DescontoProduto = 0m;
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
                if (servicoSelecionadoTemporario.QuantidadeVendida > 0)
                {
                    servicoSelecionadoTemporario.Desconto = DescontoServico;
                    ServicosSelecionados.Add(servicoSelecionadoTemporario);
                    servicoSelecionadoTemporario = new OrdemVendaServico();
                    ValorTotalProdutos = 0m;
                    ValorTotalServicos = 0m;
                    DescontoServico = 0m;
                    AtualizaValorTotal();
                }
                await Navigation.PopAsync();
                IsBusy = false;
            }
        }

        #region HelpCommand

        Command _EditarVendaClienteFuncionarioHelpCommand;
        public Command EditarVendaClienteFuncionarioHelpCommand
        {
            get { return _EditarVendaClienteFuncionarioHelpCommand ?? (_EditarVendaClienteFuncionarioHelpCommand = new Command(async () => await ExecuteEditarVendaClienteFuncionarioHelpCommand())); }
        }

        async Task ExecuteEditarVendaClienteFuncionarioHelpCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarVendaClienteFuncionarioHelpPage());
                IsBusy = false;
            }
        }

        Command _EditarVendaClienteListaHelpCommand;
        public Command EditarVendaClienteListaHelpCommand
        {
            get { return _EditarVendaClienteListaHelpCommand ?? (_EditarVendaClienteListaHelpCommand = new Command(async () => await ExecuteEditarVendaClienteListaHelpCommand())); }
        }

        async Task ExecuteEditarVendaClienteListaHelpCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarVendaClienteListaHelpPage());
                IsBusy = false;
            }
        }

        Command _EditarVendaConclusaoHelpCommand;
        public Command EditarVendaConclusaoHelpCommand
        {
            get { return _EditarVendaConclusaoHelpCommand ?? (_EditarVendaConclusaoHelpCommand = new Command(async () => await ExecuteEditarVendaConclusaoHelpCommand())); }
        }

        async Task ExecuteEditarVendaConclusaoHelpCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarVendaConclusaoHelpPage());
                IsBusy = false;
            }
        }

        Command _EditarVendaFuncionarioListaHelpCommand;
        public Command EditarVendaFuncionarioListaHelpCommand
        {
            get { return _EditarVendaFuncionarioListaHelpCommand ?? (_EditarVendaFuncionarioListaHelpCommand = new Command(async () => await ExecuteEditarVendaFuncionarioListaHelpCommand())); }
        }

        async Task ExecuteEditarVendaFuncionarioListaHelpCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarVendaFuncionarioListaHelpPage());
                IsBusy = false;
            }
        }

        Command _EditarVendaProdutoHelpCommand;
        public Command EditarVendaProdutoHelpCommand
        {
            get { return _EditarVendaProdutoHelpCommand ?? (_EditarVendaProdutoHelpCommand = new Command(async () => await ExecuteEditarVendaProdutoHelpCommand())); }
        }

        async Task ExecuteEditarVendaProdutoHelpCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarVendaProdutoHelpPage());
                IsBusy = false;
            }
        }

        Command _EditarVendaProdutoListaHelpCommand;
        public Command EditarVendaProdutoListaHelpCommand
        {
            get { return _EditarVendaProdutoListaHelpCommand ?? (_EditarVendaProdutoListaHelpCommand = new Command(async () => await ExecuteEditarVendaProdutoListaHelpCommand())); }
        }

        async Task ExecuteEditarVendaProdutoListaHelpCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarVendaProdutoListaHelpPage());
                IsBusy = false;
            }
        }

        Command _EditarVendaProdutoQuantidadeHelpCommand;
        public Command EditarVendaProdutoQuantidadeHelpCommand
        {
            get { return _EditarVendaProdutoQuantidadeHelpCommand ?? (_EditarVendaProdutoQuantidadeHelpCommand = new Command(async () => await ExecuteEditarVendaProdutoQuantidadeHelpCommand())); }
        }

        async Task ExecuteEditarVendaProdutoQuantidadeHelpCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarVendaProdutoQuantidadeHelpPage());
                IsBusy = false;
            }
        }

        Command _EditarVendaServicoHelpCommand;
        public Command EditarVendaServicoHelpCommand
        {
            get { return _EditarVendaServicoHelpCommand ?? (_EditarVendaServicoHelpCommand = new Command(async () => await ExecuteEditarVendaServicoHelpCommand())); }
        }

        async Task ExecuteEditarVendaServicoHelpCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarVendaServicoHelpPage());
                IsBusy = false;
            }
        }

        Command _EditarVendaServicoListaHelpCommand;
        public Command EditarVendaServicoListaHelpCommand
        {
            get { return _EditarVendaServicoListaHelpCommand ?? (_EditarVendaServicoListaHelpCommand = new Command(async () => await ExecuteEditarVendaServicoListaHelpCommand())); }
        }

        async Task ExecuteEditarVendaServicoListaHelpCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarVendaServicoListaHelpPage());
                IsBusy = false;
            }
        }

        Command _EditarVendaServicoQuantidadeHelpCommand;
        public Command EditarVendaServicoQuantidadeHelpCommand
        {
            get { return _EditarVendaServicoQuantidadeHelpCommand ?? (_EditarVendaServicoQuantidadeHelpCommand = new Command(async () => await ExecuteEditarVendaServicoQuantidadeHelpCommand())); }
        }

        async Task ExecuteEditarVendaServicoQuantidadeHelpCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarVendaServicoQuantidadeHelpPage());
                IsBusy = false;
            }
        }

        #endregion

        #endregion
    }
}