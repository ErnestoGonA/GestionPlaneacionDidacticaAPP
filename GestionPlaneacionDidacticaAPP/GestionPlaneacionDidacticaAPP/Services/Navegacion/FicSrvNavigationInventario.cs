using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

using GestionPlaneacionDidacticaAPP.ViewModels.Planeacion;
using GestionPlaneacionDidacticaAPP.Views.Planeacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.ViewModels.Temas;
using GestionPlaneacionDidacticaAPP.Views.Temas;
using GestionPlaneacionDidacticaAPP.Views.Navegacion;
using GestionPlaneacionDidacticaAPP.ViewModels.Apoyos_Didacticos;
using GestionPlaneacionDidacticaAPP.Views.Apoyos_Didacticos;

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

            {typeof(FicVmTemasList),typeof(ViTemasList) },
            {typeof(FicVmTemasInsert),typeof(ViTemasInsert) },
            {typeof(FicVmTemasView),typeof(ViTemasView) },
            {typeof(FicVmTemasUpdate),typeof(ViTemasUpdate) },

            {typeof(VmApoyosDidacticosList),typeof(ViApoyosDidacticos) },
           
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
