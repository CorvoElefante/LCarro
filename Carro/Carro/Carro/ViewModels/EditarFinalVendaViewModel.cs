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
    public class EditarFinalVendaViewModel : BaseViewModel
    {
        public EditarFinalVendaViewModel(INavigation navigation, OrdemVenda value) : base(navigation)
        {
            idEntry = value.Id;
            pessoaSelecionada = value.Pessoa;
            FormaPagamento = value.FormaPagamento;
            Parcelas = value.Parcelas;
            Entrada = value.Entrada;
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

        #endregion

        #region Commands

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


        Command _EditarFinalVendaProdutoCommand;
        public Command EditarFinalVendaProdutoCommand
        {
            get { return _EditarFinalVendaProdutoCommand ?? (_EditarFinalVendaProdutoCommand = new Command(async () => await ExecuteEditarFinalVendaProdutoCommand())); }
        }

        async Task ExecuteEditarFinalVendaProdutoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarFinalVendaProdutoPage(this));
                IsBusy = false;
            }
        }

        Command _EditarFinalVendaServicoCommand;
        public Command EditarFinalVendaServicoCommand
        {
            get { return _EditarFinalVendaServicoCommand ?? (_EditarFinalVendaServicoCommand = new Command(async () => await ExecuteEditarFinalVendaServicoCommand())); }
        }

        async Task ExecuteEditarFinalVendaServicoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarFinalVendaServicoPage(this));
                IsBusy = false;
            }
        }

        Command _EditarFinalVendaConclusaoCommand;
        public Command EditarFinalVendaConclusaoCommand
        {
            get { return _EditarFinalVendaConclusaoCommand ?? (_EditarFinalVendaConclusaoCommand = new Command(async () => await ExecuteEditarFinalVendaConclusaoCommand())); }
        }

        async Task ExecuteEditarFinalVendaConclusaoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                AtualizaDescontoTotalIndividual();
                AtualizaValorTotalComDesconto();
                await Navigation.PushAsync(new EditarFinalVendaConclusaoPage(this));
                IsBusy = false;
            }
        }

        Command _EditarFinalVendaParcelaCommand;
        public Command EditarFinalVendaParcelaCommand
        {
            get { return _EditarFinalVendaParcelaCommand ?? (_EditarFinalVendaParcelaCommand = new Command(async () => await ExecuteEditarFinalVendaParcelaCommand())); }
        }

        async Task ExecuteEditarFinalVendaParcelaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarFinalVendaParcelaPage());
                IsBusy = false;
            }
        }

        #region HelpCommand

        Command _EditarFinalVendaClienteFuncionarioHelpCommand;
        public Command EditarFinalVendaClienteFuncionarioHelpCommand
        {
            get { return _EditarFinalVendaClienteFuncionarioHelpCommand ?? (_EditarFinalVendaClienteFuncionarioHelpCommand = new Command(async () => await ExecuteEditarFinalVendaClienteFuncionarioHelpCommand())); }
        }

        async Task ExecuteEditarFinalVendaClienteFuncionarioHelpCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarFinalVendaClienteFuncionarioHelpPage());
                IsBusy = false;
            }
        }

        Command _EditarFinalVendaConclusaoHelpCommand;
        public Command EditarFinalVendaConclusaoHelpCommand
        {
            get { return _EditarFinalVendaConclusaoHelpCommand ?? (_EditarFinalVendaConclusaoHelpCommand = new Command(async () => await ExecuteEditarFinalVendaConclusaoHelpCommand())); }
        }

        async Task ExecuteEditarFinalVendaConclusaoHelpCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarFinalVendaConclusaoHelpPage());
                IsBusy = false;
            }
        }

        Command _EditarFinalVendaProdutoHelpCommand;
        public Command EditarFinalVendaProdutoHelpCommand
        {
            get { return _EditarFinalVendaProdutoHelpCommand ?? (_EditarFinalVendaProdutoHelpCommand = new Command(async () => await ExecuteEditarFinalVendaProdutoHelpCommand())); }
        }

        async Task ExecuteEditarFinalVendaProdutoHelpCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarFinalVendaProdutoHelpPage());
                IsBusy = false;
            }
        }

        Command _EditarFinalVendaServicoHelpCommand;
        public Command EditarFinalVendaServicoHelpCommand
        {
            get { return _EditarFinalVendaServicoHelpCommand ?? (_EditarFinalVendaServicoHelpCommand = new Command(async () => await ExecuteEditarFinalVendaServicoHelpCommand())); }
        }

        async Task ExecuteEditarFinalVendaServicoHelpCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarFinalVendaServicoHelpPage());
                IsBusy = false;
            }
        }

        #endregion

        #endregion
    }
}