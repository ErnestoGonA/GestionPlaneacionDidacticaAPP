using GestionPlaneacionDidacticaAPP.ViewModels.Planeacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestionPlaneacionDidacticaAPP.Views.Planeacion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViPlaneacionView : ContentPage
	{
        private object FicCuerpoNavigationContext { get; set; }
        public FicViPlaneacionView (object FicNavigationContext)
		{
			InitializeComponent ();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmPlaneacionView;
        }
        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmPlaneacionView;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;

                FicViewModel.OnAppearing();

            }
        }
    }
}