using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GestionPlaneacionDidacticaAPP.ViewModels.ActividadEnseñanza;

namespace GestionPlaneacionDidacticaAPP.Views.ActividadEnseñanza
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViActividadEnseñanzaDetalle : ContentPage
	{
        private object FicCuerpoNavigationContext { get; set; }
        public FicViActividadEnseñanzaDetalle (object FicNavigationContext)
		{
			InitializeComponent ();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmActividadEnseñanzaDetalle;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmActividadEnseñanzaDetalle;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;
                FicViewModel.OnAppearing();

            }
        }
    }
}