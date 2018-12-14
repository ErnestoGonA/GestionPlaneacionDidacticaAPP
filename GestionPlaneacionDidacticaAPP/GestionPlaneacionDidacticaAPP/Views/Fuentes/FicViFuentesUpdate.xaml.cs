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
	public partial class FicViFuentesUpdate : ContentPage
	{
        private object[] FicCuerpoNavigationContext { get; set; }

        public FicViFuentesUpdate(object[] FicNavigationContext)
        {
            InitializeComponent();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmFuentesUpdate;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmFuentesUpdate;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;
                FicViewModel.OnAppearing();
            }
        }
    }
}