using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.CriteriosEvaluacion;

namespace GestionPlaneacionDidacticaAPP.Views.CriteriosEvaluacion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViCriteriosEvaluacionUpdate : ContentPage
	{
        private object[] FicCuerpoNavigationContext { get; set; }

        public ViCriteriosEvaluacionUpdate(object[] FicNavigationContext)
        {
            InitializeComponent();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmCriteriosEvaluacionUpdate;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCriteriosEvaluacionUpdate;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;
                FicViewModel.OnAppearing();
            }
        }

    }
}