using GestionPlaneacionDidacticaAPP.ViewModels.Fuentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestionPlaneacionDidacticaAPP.Views.Fuentes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViFuentesInsert : ContentPage
	{

        private object CuerpoNavigationContext { get; set; }

        public FicViFuentesInsert(object NavigationContext)
        {
            InitializeComponent();
            CuerpoNavigationContext = NavigationContext;
            BindingContext = App.FicVmLocator.FicVmFuentesInsert;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmFuentesInsert;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = CuerpoNavigationContext;
                FicViewModel.OnAppearing();
            }

        }
    }
}