using GestionPlaneacionDidacticaAPP.ViewModels.Subtemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestionPlaneacionDidacticaAPP.Views.Subtemas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViSubtemaView : ContentPage
	{

        private object[] FicCuerpoNavigationContext { get; set; }

        public FicViSubtemaView(object[] FicNavigationContext)
        {
            InitializeComponent();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.ficVmSubtemaView;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmSubtemaView;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;
                FicViewModel.OnAppearing();

            }
        }
    }
}