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
    public partial class FicViSubtemasList : ContentPage
    {
        private object FicCuerpoNavigationContext { get; set; }

        public FicViSubtemasList()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmSubtemaList;
        }


        public FicViSubtemasList(object NavigationContext)
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmSubtemaList;
            FicCuerpoNavigationContext = NavigationContext;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmSubtemaList;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;
                FicViewModel.OnAppearing();
            }
        }

    }//
}