using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Views.Navegacion;
using GestionPlaneacionDidacticaAPP.Views.Planeacion;
using GestionPlaneacionDidacticaAPP.Views.Temas;
using GestionPlaneacionDidacticaAPP.Views.CriteriosEvaluacion;
using GestionPlaneacionDidacticaAPP.Views.Apoyos_Didacticos;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.ViewModels.Planeacion;
using GestionPlaneacionDidacticaAPP.ViewModels.Temas;
using GestionPlaneacionDidacticaAPP.ViewModels.CriteriosEvaluacion;
using GestionPlaneacionDidacticaAPP.ViewModels.Apoyos_Didacticos;


namespace GestionPlaneacionDidacticaAPP.Services.Navegacion
{
    public class FicSrvNavigationInventario : IFicSrvNavigationInventario
    {
        private IDictionary<Type, Type> FicViewModelRouting = new Dictionary<Type, Type>()
        {
            //AQUI SE HACE UNA UNION ENTRE LA VM Y VI DE CADA VIEW DE LA APP
            {typeof(FicVmPlaneacion),typeof(FicViPlaneacion) },
            {typeof(FicVmPlaneacionInsert),typeof(FicViPlaneacionInsert) },
            {typeof(FicVmPlaneacionView),typeof(FicViPlaneacionView) },
            {typeof(FicVmPlaneacionUpdate),typeof(FicViPlaneacionUpdate) },
            {typeof(FicVmPlaneacionGuardarComo),typeof(FicViPlaneacionGuardarComo) },

            {typeof(FicVmTemasList),typeof(ViTemasList) },
            {typeof(FicVmTemasInsert),typeof(ViTemasInsert) },
            {typeof(FicVmTemasView),typeof(ViTemasView) },
            {typeof(FicVmTemasUpdate),typeof(ViTemasUpdate) },

            {typeof(FicVmCriteriosEvaluacionList),typeof(ViCriteriosEvaluacionList) },

            {typeof(VmApoyosDidacticosList),typeof(ViApoyosDidacticos) },
            {typeof(FicVmApoyosDidacticosUpdate),typeof(FicViApoyosDidacticosUpdate) },
            {typeof(FicVmApoyosDidacticosInsert),typeof(FicViApoyosDidacticosInsert) },
            {typeof(FicVmApoyosDidacticosView),typeof(FicViApoyosDidacticosView) },

        };

        #region METODOS DE IMPLEMENTACION DE LA INTERFACE -> IFicSrvNavigationInventario
        public void FicMetNavigateTo<FicTDestinationViewModel>(object FicNavigationContext = null)
        {
            Type FicPageType = FicViewModelRouting[typeof(FicTDestinationViewModel)];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext) as Page;

            if (FicPage != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushAsync(FicPage);
            }
        }

        public void FicMetNavigateTo(Type FicDestinationType, object FicNavigationContext = null)
        {
            Type FicPageType = FicViewModelRouting[FicDestinationType];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext) as Page;

            if (FicPage != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushAsync(FicPage);
            }
        }

        public void FicMetNavigateBack()
        {
            Application.Current.MainPage.Navigation.PopAsync(true);
        }
        #endregion

    }//CLASS
}//NAMESPACE
