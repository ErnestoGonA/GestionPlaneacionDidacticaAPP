using GestionPlaneacionDidacticaAPP.ViewModels.ActividadEnseñanza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestionPlaneacionDidacticaAPP.Views.ActividadEnseñanza
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViActividadEnseñanzaUpdate : ContentPage
	{
        private object FicCuerpoNavigationContext { get; set; }
        public FicViActividadEnseñanzaUpdate (object FicNavigationContext)
		{
			InitializeComponent ();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmActividadEnseñanzaUpdate;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmActividadEnseñanzaUpdate;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;

                FicViewModel.OnAppearing();

            }
        }//SE EJECUTA CUANDO SE ABRE LA VIEW
    }
}