using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.ViewModels.Aprendizajes;

namespace GestionPlaneacionDidacticaAPP.Views.Aprendizajes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViAprendizajesList : ContentPage
	{

        private object[] FicCuerpoNavigationContext { get; set; }

        public FicViAprendizajesList()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmAprendizajesList;
        }


        public FicViAprendizajesList(object[] NavigationContext)
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmAprendizajesList;
            FicCuerpoNavigationContext = NavigationContext;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmAprendizajesList;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;
                FicViewModel.OnAppearing();
            }
        }
        private async void OnFilterTextChange(object sender, TextChangedEventArgs e)
        {
            var FicViewModel = BindingContext as FicVmAprendizajesList;
            FicViewModel.FilterTextChange(e.NewTextValue);
        }
    }
}