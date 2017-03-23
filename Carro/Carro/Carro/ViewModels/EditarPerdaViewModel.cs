using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Carro.Models;
using System.Collections.Generic;
using Carro.Repositories;
using Carro.Services;
using System.Threading.Tasks;
using Carro.Pages;

namespace Carro.ViewModels
{
    public class EditarPerdaViewModel : BaseViewModel
    {

        public EditarPerdaViewModel(INavigation navigation, Carro.ViewModels.ListaPerdaViewModel.ListaProdutoPerda value) : base(navigation)
        {

            var sqlite = DependencyService.Get<ISQLite>();

        }

        public class ListaProduto
        {
            public long? Id { get; set; }

            public string Nome { get; set; }

            public float Preco { get; set; }

            public int Quantidade { get; set; }

            public string Marca { get; set; }

            public string Descricao { get; set; }

            public string Local { get; set; }

            public int QuantidadePerdida { get; set; }
        }

        ObservableCollection<ListaProduto> _ListaProdutoPerdas;
        public ObservableCollection<ListaProduto> ListaProdutoPerdas
        {
            get
            {
                return _ListaProdutoPerdas;
            }
            set
            {
                _ListaProdutoPerdas = value;
                SetPropertyChanged(nameof(ListaProdutoPerdas));
            }
        }

        string _nomeEntry = string.Empty;
        public string nomeEntry
        {
            get
            {
                return _nomeEntry;
            }
            set
            {
                _nomeEntry = value;
                SetPropertyChanged(nameof(nomeEntry));
            }
        }

        string _justificativaEntry = string.Empty;
        public string justificativaEntry
        {
            get
            {
                return _justificativaEntry;
            }
            set
            {
                _justificativaEntry = value;
                SetPropertyChanged(nameof(justificativaEntry));
            }
        }
    }
}
