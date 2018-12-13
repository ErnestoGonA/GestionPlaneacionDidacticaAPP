using GestionPlaneacionDidacticaAPP.ViewModels.Planeacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestionPlaneacionDidacticaAPP.Views.Planeacion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViPlaneacion : ContentPage
	{
        public FicViPlaneacion()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmPlaneacion;
        }
        public FicViPlaneacion(object NavigationContext)
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmPlaneacion;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmPlaneacion;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing();
            }
        }

        private async void OnFilterTextChange(object sender, TextChangedEventArgs e)
        {
            var FicViewModel = BindingContext as FicVmPlaneacion;
            FicViewModel.FilterTextChange(e.NewTextValue);
        }
    }
}