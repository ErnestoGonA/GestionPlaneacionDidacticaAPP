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
	public partial class FicViPlaneacionApoyosList : ContentPage
	{
        private object FicCuerpoNavigationContext { get; set; }

        public FicViPlaneacionApoyosList ()
		{
			InitializeComponent ();
            BindingContext = App.FicVmLocator.FicVmPlaneacionApoyosList;
        }

        public FicViPlaneacionApoyosList(object NavigationContext)
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmPlaneacionApoyosList;
            FicCuerpoNavigationContext = NavigationContext;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmPlaneacionApoyosList;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;
                FicViewModel.OnAppearing();
            }
        }

     
    }
}