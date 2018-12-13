using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.ViewModels.CriteriosEvaluacion;


namespace GestionPlaneacionDidacticaAPP.Views.CriteriosEvaluacion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViCriteriosEvaluacionInsert : ContentPage
	{
        private object[] CuerpoNavigationContext { get; set; }

        //TODO: delete this constructor when have the father view
        public ViCriteriosEvaluacionInsert()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmCriteriosEvaluacionInsert;
        }

        public ViCriteriosEvaluacionInsert(object[] NavigationContext)
        {
            InitializeComponent();
            CuerpoNavigationContext = NavigationContext;
            BindingContext = App.FicVmLocator.FicVmCriteriosEvaluacionInsert;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCriteriosEvaluacionInsert;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = CuerpoNavigationContext;
                FicViewModel.OnAppearing();
            }

        }

    }
}