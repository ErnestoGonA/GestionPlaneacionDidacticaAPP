using GestionPlaneacionDidacticaAPP.ViewModels.Enseñanza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestionPlaneacionDidacticaAPP.Views.Enseñanza
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViEnseñanzaDetalle : ContentPage
	{
        private object[] FicCuerpoNavigationContext { get; set; }
        public FicViEnseñanzaDetalle (object[] FicNavigationContext)
		{
			InitializeComponent ();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmEnseñanzaDetalle;
        }
        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmEnseñanzaDetalle;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;

                FicViewModel.OnAppearing();

            }
        }
    }
}