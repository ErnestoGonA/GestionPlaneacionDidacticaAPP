using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels;
using GestionPlaneacionDidacticaAPP.ViewModels.Temas;

namespace GestionPlaneacionDidacticaAPP.Views.Temas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViTemasView : ContentPage
	{

        private object FicCuerpoNavigationContext { get; set; }

        public ViTemasView(object FicNavigationContext)
        {
			InitializeComponent ();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmTemasView;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmTemasView;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;
                FicViewModel.OnAppearing();

            }
        }

    }
}