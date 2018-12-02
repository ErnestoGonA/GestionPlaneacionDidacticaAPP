using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.ViewModels.Temas;

namespace GestionPlaneacionDidacticaAPP.Views.Temas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViTemasList : ContentPage
    {
        public ViTemasList()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.VmTemasList;
        }

        public ViTemasList(object NavigationContext)
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.VmTemasList;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as VmTemasList;
            if (FicViewModel != null)
            {
               FicViewModel.OnAppearing();
            }
        }

    }
}