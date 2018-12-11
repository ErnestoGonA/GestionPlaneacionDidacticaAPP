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
	public partial class ViCriteriosEvaluacionView : ContentPage
	{
        private object[] FicCuerpoNavigationContext { get; set; }

        public ViCriteriosEvaluacionView(object[] FicNavigationContext)
        {
            InitializeComponent();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmCriteriosEvaluacionView;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCriteriosEvaluacionView;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;
                FicViewModel.OnAppearing();
            }
        }

    }
}