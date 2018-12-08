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
	public partial class FicViApoyosDidacticosInsert : ContentPage
	{
        private object[] CuerpoNavigationContext { get; set; }

        public FicViApoyosDidacticosInsert (object[] NavigationContext)
		{
			InitializeComponent ();
            CuerpoNavigationContext = NavigationContext;
            BindingContext = App.FicVmLocator.FicVmApoyosDidacticosInsert;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmApoyosDidacticosInsert;
            if (FicViewModel != null)
            {
                FicViewModel.NavigationContextC = CuerpoNavigationContext;
            }
        }
    }
}