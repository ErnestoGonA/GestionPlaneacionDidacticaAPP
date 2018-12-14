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
	public partial class FicViAprendizajesUpdate : ContentPage
	{
        private object[] FicCuerpoNavigationContext { get; set; }

        public FicViAprendizajesUpdate()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmAprendizajesUpdate;
        }

        public FicViAprendizajesUpdate(object[] NavigationContext)
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmAprendizajesUpdate;
            FicCuerpoNavigationContext = NavigationContext;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmAprendizajesUpdate;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;
                FicViewModel.OnAppearing();
            }
        }
    }
}