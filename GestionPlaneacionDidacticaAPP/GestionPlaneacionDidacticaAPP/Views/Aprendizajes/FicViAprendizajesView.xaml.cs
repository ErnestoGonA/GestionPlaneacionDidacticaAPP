using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.ViewModels.Aprendizajes;

namespace GestionPlaneacionDidacticaAPP.Views.Aprendizajes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViAprendizajesView : ContentPage
	{
        private object[] FicCuerpoNavigationContext { get; set; }

        public FicViAprendizajesView()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmAprendizajesView;
        }

        public FicViAprendizajesView(object[] NavigationContext)
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmAprendizajesView;
            FicCuerpoNavigationContext = NavigationContext;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmAprendizajesView;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;
                FicViewModel.OnAppearing();
            }
        }
    }
}