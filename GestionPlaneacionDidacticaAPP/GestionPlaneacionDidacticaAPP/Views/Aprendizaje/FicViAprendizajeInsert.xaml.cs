using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GestionPlaneacionDidacticaAPP.ViewModels.Aprendizaje;

namespace GestionPlaneacionDidacticaAPP.Views.Aprendizaje
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViAprendizajeInsert : ContentPage
	{
        private object[] CuerpoNavigationContext { get; set; }

        public FicViAprendizajeInsert (object[] NavigationContext)
		{
			InitializeComponent ();
            CuerpoNavigationContext = NavigationContext;
            BindingContext = App.FicVmLocator.FicVmAprendizajeInsert;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmAprendizajeInsert;
            if (FicViewModel != null)
            {
                FicViewModel.NavigationContextC = CuerpoNavigationContext;
            }
        }
    }
}