using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GestionPlaneacionDidacticaAPP.ViewModels.Apoyos_Didacticos;

namespace GestionPlaneacionDidacticaAPP.Views.Apoyos_Didacticos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViApoyosDidacticosUpdate : ContentPage
	{
        private object CuerpoNavigationContext { get; set; }

        public FicViApoyosDidacticosUpdate (object FicNavigationContext)
		{
			InitializeComponent ();
            CuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmApoyosDidacticosUpdate;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmApoyosDidacticosUpdate;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = CuerpoNavigationContext;

                FicViewModel.OnAppearing();
            }
        }

    }
}