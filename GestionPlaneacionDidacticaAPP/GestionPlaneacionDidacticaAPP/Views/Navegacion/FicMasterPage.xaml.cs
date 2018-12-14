using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GestionPlaneacionDidacticaAPP.Views.Temas;
using GestionPlaneacionDidacticaAPP.Views.CriteriosEvaluacion;
using GestionPlaneacionDidacticaAPP.Views.Apoyos_Didacticos;
using GestionPlaneacionDidacticaAPP.Views.Planeacion;
using GestionPlaneacionDidacticaAPP.Views.Subtemas;
using GestionPlaneacionDidacticaAPP.Views.Competencias;
using GestionPlaneacionDidacticaAPP.Views.Planeacion_Apoyos;

namespace GestionPlaneacionDidacticaAPP.Views.Navegacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicMasterPage : MasterDetailPage
    {
        public FicMasterPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }//CONSTRUCTOR

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var FicItemMenu = e.SelectedItem as FicMasterPageMenuItem;
                if (FicItemMenu == null)
                    return;

                var FicPagina = FicItemMenu.FicPageName as string;
                switch (FicPagina)
                {
                    
                    //case "ViTemasList":
                    //    FicItemMenu.TargetType = typeof(ViTemasList);
                    //    break;

                    //case "ViCriteriosEvaluacionList":
                    //    FicItemMenu.TargetType = typeof(ViCriteriosEvaluacionList);
                    //    break;
                    case "FicViPlaneacionApoyosList":
                        FicItemMenu.TargetType = typeof(FicViPlaneacionApoyosList);
                        break;

                    case "FicViPlaneacion":
                        FicItemMenu.TargetType = typeof(FicViPlaneacion);
                        break;

                    //case "FicViSubtemasList":
                    //    FicItemMenu.TargetType = typeof(FicViSubtemasList);
                    //    break;
                    //case "FicViCompetencias":

                    //    FicItemMenu.TargetType = typeof(FicViCompetencias);
                    //    break;
                    //case "ViCatEdificiosList":
                    //    FicItemMenu.TargetType = typeof(ViCatEdificiosList);
                    //    break;

                    //case "ViCatEdificiosImportarExportar":
                    //    FicItemMenu.TargetType = typeof(ViCatEdificiosImportarExportar);
                    //    break;

                    default:
                        break;
                }

                object[] FicObjeto = new object[1];
                //FIC: Sin enviar parametro
                var FicPageOpen = (Page)Activator.CreateInstance(FicItemMenu.TargetType);
                //var FicPageOpen = Activator.CreateInstance(typeof(FicViInventarioList)) as Page;

                //FIC: Enviando como parametro un objeto vacio
                FicPageOpen.Title = FicItemMenu.Title;

                Detail = new NavigationPage(FicPageOpen);
                IsPresented = false;
                MasterPage.ListView.SelectedItem = null;
            }
            catch (Exception ex)
            {
                new Page().DisplayAlert("ERROR", ex.Message.ToString(), "OK");
            }
        }//AL SELECCIONAR UN ITEM DE DE LA LISTA

    }//CLASS
}//NAMESPACE