using GestionPlaneacionDidacticaAPP.ViewModels.ActividadEnseñanza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestionPlaneacionDidacticaAPP.Views.ActividadEnseñanza
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViActividadEnseñanza : ContentPage
    {
        public FicViActividadEnseñanza()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmActividadEnseñanza;
        }

        public FicViActividadEnseñanza(object FicNavigationContext)
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmActividadEnseñanza;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmActividadEnseñanza;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing();
            }
        }
    }
}