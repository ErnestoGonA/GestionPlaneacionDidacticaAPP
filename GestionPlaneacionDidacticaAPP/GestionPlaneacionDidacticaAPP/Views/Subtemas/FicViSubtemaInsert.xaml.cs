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
	public partial class FicViSubtemaInsert : ContentPage
	{

        private object CuerpoNavigationContext { get; set; }

        public FicViSubtemaInsert (object NavigationContext)
		{
			InitializeComponent ();
            CuerpoNavigationContext = NavigationContext;
            BindingContext = App.FicVmLocator.FicVmSubtemaInsert;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmSubtemaInsert;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = CuerpoNavigationContext;
                FicViewModel.OnAppearing();
            }

        }
    }
}