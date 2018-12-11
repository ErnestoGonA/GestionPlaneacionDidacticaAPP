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
	public partial class FicViCompetenciasUpdate : ContentPage
	{
        private object[] FicCuerpoNavigationContext { get; set; }

        public FicViCompetenciasUpdate (object[] FicNavigationContext)
		{
			InitializeComponent ();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmCompetenciasUpdate;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCompetenciasUpdate;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;
                FicViewModel.OnAppearing();
            }
        }
    }
}