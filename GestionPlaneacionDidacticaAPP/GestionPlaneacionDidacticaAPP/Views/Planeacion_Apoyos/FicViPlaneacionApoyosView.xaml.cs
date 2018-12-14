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
	public partial class FicViPlaneacionApoyosView : ContentPage
	{
        private object[] FicCuerpoNavigationContext { get; set; }

        public FicViPlaneacionApoyosView(object[] FicNavigationContext)
        {
            InitializeComponent();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmPlaneacionApoyosView;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmPlaneacionApoyosView;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;
                FicViewModel.OnAppearing();

            }
        }
    }
}