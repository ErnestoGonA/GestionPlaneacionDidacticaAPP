using GestionPlaneacionDidacticaAPP.ViewModels.Enseñanza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestionPlaneacionDidacticaAPP.Views.Enseñanza
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViEnseñanzaList : ContentPage
    {
        public FicViEnseñanzaList()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmEnseñanzaList;
        }
        private object[] FicCuerpoNavigationContext { get; set; }
        public FicViEnseñanzaList(object[] FicNavigationContext)
        {
            InitializeComponent();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmEnseñanzaList;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmEnseñanzaList;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;

                FicViewModel.OnAppearing();

            }
        }

        private async void OnFilterTextChange(object sender, TextChangedEventArgs e)
        {
            var FicViewModel = BindingContext as FicVmEnseñanzaList;
            FicViewModel.FilterTextChange(e.NewTextValue);
        }
    }
}