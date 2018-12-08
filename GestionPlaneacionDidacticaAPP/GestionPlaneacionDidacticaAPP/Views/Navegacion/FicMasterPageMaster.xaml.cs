using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GestionPlaneacionDidacticaAPP.Views.Navegacion;
using GestionPlaneacionDidacticaAPP.Views.Temas;
using GestionPlaneacionDidacticaAPP.Views.CriteriosEvaluacion;
using GestionPlaneacionDidacticaAPP.Views.Apoyos_Didacticos;
using GestionPlaneacionDidacticaAPP.Views.Planeacion;

namespace GestionPlaneacionDidacticaAPP.Views.Navegacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicMasterPageMaster : ContentPage
    {
        public ListView ListView;

        public FicMasterPageMaster()
        {
            InitializeComponent();

            BindingContext = new FicMasterPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class FicMasterPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FicMasterPageMenuItem> MenuItems { get; }

            public FicMasterPageMasterViewModel()
            {

                MenuItems = new ObservableCollection<FicMasterPageMenuItem>(new[]
                {
                    new FicMasterPageMenuItem { Id = 3, Title = "Planeaciones", Icon ="ficAlmacen20x20.png", FicPageName ="FicViPlaneacion", TargetType = typeof(FicViPlaneacion)},

                    //new FicMasterPageMenuItem { Id = 1, Title="Temas",Icon ="ficAlmacen20x20.png",FicPageName="ViTemasList",TargetType = typeof(ViTemasList)},

                    new FicMasterPageMenuItem { Id = 1, Title="Criterios",Icon ="ficAlmacen20x20.png",FicPageName="ViCriteriosEvaluacionList",TargetType = typeof(ViCriteriosEvaluacionList)},

                    new FicMasterPageMenuItem { Id = 2, Title = "ApoyosDidacticos", Icon ="ficAlmacen20x20.png", FicPageName ="ViApoyosDidacticos", TargetType = typeof(ViApoyosDidacticos)},
                    
                });

            }//CONSTRUCTOR

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }//CLASS FicMasterPageMasterViewModel
    }//CLASS FicMasterPageMaster
}//NAMESPACE