using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            BindingContext = new MenuViewModel(Navigation);
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private double width;
        private double height;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    Menu.RowDefinitions.Clear();
                    Menu.ColumnDefinitions.Clear();
                    Menu.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    Menu.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    Menu.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    Menu.Children.Remove(PreVenda);
                    Menu.Children.Remove(Venda);
                    Menu.Children.Remove(Cliente);
                    Menu.Children.Remove(Produto);
                    Menu.Children.Remove(Servico);
                    Menu.Children.Remove(Despesa);
                    Menu.Children.Remove(Perda);
                    Menu.Children.Remove(Funcionario);
                    Menu.Children.Remove(Relatorio);
                    Menu.Children.Remove(Opcao);
                    Menu.Children.Add(PreVenda, 0, 0);
                    Menu.Children.Add(Venda, 0, 1);
                    Menu.Children.Add(Cliente, 1, 0);
                    Menu.Children.Add(Produto, 1, 1);
                    Menu.Children.Add(Servico, 2, 0);
                    Menu.Children.Add(Despesa, 2, 1);
                    Menu.Children.Add(Perda, 3, 0);
                    Menu.Children.Add(Funcionario, 3, 1);
                    Menu.Children.Add(Relatorio, 4, 0);
                    Menu.Children.Add(Opcao, 4, 1);
                }
                else
                {
                    Menu.RowDefinitions.Clear();
                    Menu.ColumnDefinitions.Clear();
                    Menu.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    Menu.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    Menu.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    Menu.Children.Remove(PreVenda);
                    Menu.Children.Remove(Venda);
                    Menu.Children.Remove(Cliente);
                    Menu.Children.Remove(Produto);
                    Menu.Children.Remove(Servico);
                    Menu.Children.Remove(Despesa);
                    Menu.Children.Remove(Perda);
                    Menu.Children.Remove(Funcionario);
                    Menu.Children.Remove(Relatorio);
                    Menu.Children.Remove(Opcao);
                    Menu.Children.Add(PreVenda, 0, 0);
                    Menu.Children.Add(Venda, 1, 0);
                    Menu.Children.Add(Cliente, 0, 1);
                    Menu.Children.Add(Produto, 1, 1);
                    Menu.Children.Add(Servico, 0, 2);
                    Menu.Children.Add(Despesa, 1, 2);
                    Menu.Children.Add(Perda, 0, 3);
                    Menu.Children.Add(Funcionario, 1, 3);
                    Menu.Children.Add(Relatorio, 0, 4);
                    Menu.Children.Add(Opcao, 1, 4);
                }
            }
        }
    }
}
