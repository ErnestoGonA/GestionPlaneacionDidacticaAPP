using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GestionPlaneacionDidacticaAPP.ViewModels.Aprendizaje;

namespace GestionPlaneacionDidacticaAPP.Views.Aprendizaje
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViAprendizajeList : ContentPage
    {
        public FicViAprendizajeList()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmAprendizajeList;
        }

        public FicViAprendizajeList(object FicNavegationContext)
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmAprendizajeList;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmAprendizajeList;
            if(FicViewModel != null)
            {
                FicViewModel.OnAppearing();
            }
        }
    }
}