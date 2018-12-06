using GestionPlaneacionDidacticaAPP.ViewModels.Aprendizaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestionPlaneacionDidacticaAPP.Views.Aprendizaje
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViAprendizajeUpdate : ContentPage
	{
        private object[] CuerpoNavigationContext { get; set; }

        public FicViAprendizajeUpdate (object[] NavigationContext)
		{
			InitializeComponent ();
            CuerpoNavigationContext = NavigationContext;
            BindingContext = App.FicVmLocator.FicVmAprendizajeUpdate;
        }
        

            protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmAprendizajeUpdate;
            if (FicViewModel != null)
            {
                FicViewModel.NavigationContextC = CuerpoNavigationContext;
            }
        }
    }
}