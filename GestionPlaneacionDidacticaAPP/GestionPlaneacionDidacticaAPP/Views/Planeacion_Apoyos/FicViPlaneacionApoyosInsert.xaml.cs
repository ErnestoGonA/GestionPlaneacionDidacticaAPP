using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GestionPlaneacionDidacticaAPP.ViewModels.Planeacion_Apoyos;

namespace GestionPlaneacionDidacticaAPP.Views.Planeacion_Apoyos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViPlaneacionApoyosInsert : ContentPage
	{
        private object CuerpoNavigationContext { get; set; }

        public FicViPlaneacionApoyosInsert (object NavigationContext)
		{
			InitializeComponent ();
            CuerpoNavigationContext = NavigationContext;
            BindingContext = App.FicVmLocator.FicVmPlaneacionApoyosInsert;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmPlaneacionApoyosInsert;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = CuerpoNavigationContext;
                FicViewModel.OnAppearing();
            }

        }

    }
}