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
	public partial class ViApoyosDidacticos : ContentPage
	{
		public ViApoyosDidacticos ()
		{
			InitializeComponent ();
            BindingContext = App.FicVmLocator.VmApoyosDidacticosList;
        }

        public ViApoyosDidacticos(object NavigationContext)
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.VmApoyosDidacticosList;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as VmApoyosDidacticosList;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing();
            }
        }

        private async void OnFilterTextChange(object sender, TextChangedEventArgs e)
        {
            var FicViewModel = BindingContext as VmApoyosDidacticosList;
            FicViewModel.FilterTextChange(e.NewTextValue);
        }

    }
}