using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GestionPlaneacionDidacticaAPP.ViewModels.Apoyos_Didacticos;

namespace GestionPlaneacionDidacticaAPP.Views.Apoyos_Didacticos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViApoyosDidacticosView : ContentPage
    {
        private object FicCuerpoNavigationContext { get; set; }

        public FicViApoyosDidacticosView(object[] FicNavigationContext)
        {
            InitializeComponent();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmApoyosDidacticosView;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmApoyosDidacticosView;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;
                FicViewModel.OnAppearing();

            }
        }

    }
}