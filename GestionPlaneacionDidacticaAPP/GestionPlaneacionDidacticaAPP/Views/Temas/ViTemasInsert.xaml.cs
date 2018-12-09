using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.ViewModels.Temas;

namespace GestionPlaneacionDidacticaAPP.Views.Temas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViTemasInsert : ContentPage
    {

        private object CuerpoNavigationContext { get; set; }

        public ViTemasInsert(object NavigationContext)
        {
            InitializeComponent();
            CuerpoNavigationContext = NavigationContext;
            BindingContext = App.FicVmLocator.FicVmTemasInsert;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmTemasInsert;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = CuerpoNavigationContext;
                FicViewModel.OnAppearing();
            }

        }

    }
}