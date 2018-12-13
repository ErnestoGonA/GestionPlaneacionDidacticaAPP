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
	public partial class FicViActividadEnseñanzaInsert : ContentPage
	{
        private object FicCuerpoNavigationContext { get; set; }
        public FicViActividadEnseñanzaInsert(object FicNavigationContext)
        {
			InitializeComponent ();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmActividadEnseñanzaInsert;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmActividadEnseñanzaInsert;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;

                FicViewModel.OnAppearing();

            }
        }//SE EJECUTA CUANDO SE ABRE LA VIEW
    }
}