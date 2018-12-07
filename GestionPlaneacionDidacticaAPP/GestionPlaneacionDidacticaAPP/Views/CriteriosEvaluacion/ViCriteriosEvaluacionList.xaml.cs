using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.ViewModels.CriteriosEvaluacion;

namespace GestionPlaneacionDidacticaAPP.Views.CriteriosEvaluacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViCriteriosEvaluacionList : ContentPage
    {
        private object[] FicCuerpoNavigationContext { get; set; }

        public ViCriteriosEvaluacionList()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmCriteriosEvaluacionList;
        }


        public ViCriteriosEvaluacionList(object[] NavigationContext)
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmCriteriosEvaluacionList;
            FicCuerpoNavigationContext = NavigationContext;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCriteriosEvaluacionList;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;
                FicViewModel.OnAppearing();
            }
        }

    }
}
