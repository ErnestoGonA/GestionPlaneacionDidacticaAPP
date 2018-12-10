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
        public FicViEnseñanzaList(object NavigationContext)
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmEnseñanzaList;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmEnseñanzaList;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing();
            }
        }
    }
}