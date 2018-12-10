using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GestionPlaneacionDidacticaAPP.ViewModels.Competencias;

namespace GestionPlaneacionDidacticaAPP.Views.Competencias
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCompetenciasInsert : ContentPage
	{
        private object CuerpoNavigationContext { get; set; }

        public FicViCompetenciasInsert (object NavigationContext)
		{
			InitializeComponent ();
            CuerpoNavigationContext = NavigationContext;
            BindingContext = App.FicVmLocator.FicVmCompetenciasInsert;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCompetenciasInsert;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = CuerpoNavigationContext;
                FicViewModel.OnAppearing();
            }

        }

    }
}