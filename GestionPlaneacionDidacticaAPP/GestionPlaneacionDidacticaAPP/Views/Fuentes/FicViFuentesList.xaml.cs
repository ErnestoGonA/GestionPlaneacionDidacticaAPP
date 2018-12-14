using GestionPlaneacionDidacticaAPP.ViewModels.Fuentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestionPlaneacionDidacticaAPP.Views.Navegacion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViFuentesList : ContentPage
	{
        private object FicCuerpoNavigationContext { get; set; }

        public FicViFuentesList()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmFuentesList;
        }


        public FicViFuentesList(object NavigationContext)
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmFuentesList;
            FicCuerpoNavigationContext = NavigationContext;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmFuentesList;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;
                FicViewModel.OnAppearing();
            }
        }
        private async void OnFilterTextChange(object sender, TextChangedEventArgs e)
        {
            var FicViewModel = BindingContext as FicVmFuentesList;
            FicViewModel.FilterTextChange(e.NewTextValue);
        }
    }
}