using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
	public partial class OpcaoBackupPage : ContentPage
	{
		public OpcaoBackupPage ()
		{
            BindingContext = new OpcaoBackupViewModel(Navigation);
			InitializeComponent ();
		}
	}
}