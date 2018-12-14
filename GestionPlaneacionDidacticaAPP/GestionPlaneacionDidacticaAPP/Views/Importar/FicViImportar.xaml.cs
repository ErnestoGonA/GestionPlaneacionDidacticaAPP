using GestionPlaneacionDidacticaAPP.ViewModels.Importar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestionPlaneacionDidacticaAPP.Views.Importar
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViImportar : ContentPage
	{
		public FicViImportar ()
		{
			InitializeComponent ();
            BindingContext = App.FicVmLocator.FicVmImportar;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmImportar;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing();
            }
        }
    }
}