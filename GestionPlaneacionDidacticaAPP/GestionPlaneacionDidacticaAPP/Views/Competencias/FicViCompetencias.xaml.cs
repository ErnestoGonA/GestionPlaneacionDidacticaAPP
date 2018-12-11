using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GestionPlaneacionDidacticaAPP.ViewModels.Competencias;

namespace GestionPlaneacionDidacticaAPP.Views.Competencias
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViCompetencias : ContentPage
    {
        private object FicCuerpoNavigationContext { get; set; }

        public FicViCompetencias()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmCompetenciasList;
        }

        public FicViCompetencias(object NavigationContext)
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmCompetenciasList;
            FicCuerpoNavigationContext = NavigationContext;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCompetenciasList;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;
                FicViewModel.OnAppearing();
            }
        }
    }
}