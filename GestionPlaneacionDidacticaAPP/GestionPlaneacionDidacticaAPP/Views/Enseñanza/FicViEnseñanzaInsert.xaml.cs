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
    public partial class FicViEnseñanzaInsert : ContentPage
    {
        private object[] FicCuerpoNavigationContext { get; set; }
        public FicViEnseñanzaInsert(object[] FicNavigationContext)
        {
            InitializeComponent();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmEnseñanzaInsert;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmEnseñanzaInsert;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;

                FicViewModel.OnAppearing();

            }
        }//SE EJECUTA CUANDO SE ABRE LA VIEW
    }
}