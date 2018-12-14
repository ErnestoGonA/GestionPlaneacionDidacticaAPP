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
	public partial class FicViFuentesView : ContentPage
	{
        private object[] FicCuerpoNavigationContext { get; set; }

        public FicViFuentesView(object[] FicNavigationContext)
        {
            InitializeComponent();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmFuentesView;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmFuentesView;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;
                FicViewModel.OnAppearing();

            }
        }
    }
}