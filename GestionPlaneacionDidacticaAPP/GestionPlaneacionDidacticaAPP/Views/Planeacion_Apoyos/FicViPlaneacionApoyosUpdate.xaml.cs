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
	public partial class FicViPlaneacionApoyosUpdate : ContentPage
	{
        private object[] FicCuerpoNavigationContext { get; set; }

        public FicViPlaneacionApoyosUpdate (object[] FicNavigationContext)
		{
			InitializeComponent ();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmPlaneacionApoyosUpdate;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmPlaneacionApoyosUpdate;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;
                FicViewModel.OnAppearing();
            }
        }
    }
}