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
	public partial class FicViSubtemaUpdate : ContentPage
	{
        private object[] FicCuerpoNavigationContext { get; set; }

        public FicViSubtemaUpdate(object[] FicNavigationContext)
        {
            InitializeComponent();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmSubtemasUpdate;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmSubtemasUpdate;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;
                FicViewModel.OnAppearing();
            }
        }
    }
}