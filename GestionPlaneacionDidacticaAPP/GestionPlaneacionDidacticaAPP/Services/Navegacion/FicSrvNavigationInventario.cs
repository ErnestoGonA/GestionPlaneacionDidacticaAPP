using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Views.Navegacion;
using GestionPlaneacionDidacticaAPP.Views.Planeacion;
using GestionPlaneacionDidacticaAPP.Views.Temas;
using GestionPlaneacionDidacticaAPP.ViewModels.Aprendizajes;
using GestionPlaneacionDidacticaAPP.Views.CriteriosEvaluacion;
using GestionPlaneacionDidacticaAPP.Views.Aprendizajes;
using GestionPlaneacionDidacticaAPP.Views.Apoyos_Didacticos;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.ViewModels.Planeacion;
using GestionPlaneacionDidacticaAPP.ViewModels.Temas;
using GestionPlaneacionDidacticaAPP.ViewModels.Aprendizajes;
using GestionPlaneacionDidacticaAPP.ViewModels.CriteriosEvaluacion;
using GestionPlaneacionDidacticaAPP.ViewModels.Apoyos_Didacticos;
using GestionPlaneacionDidacticaAPP.ViewModels.Enseñanza;
using GestionPlaneacionDidacticaAPP.Views.Enseñanza;
using GestionPlaneacionDidacticaAPP.ViewModels.Planeacion_Apoyos;
using GestionPlaneacionDidacticaAPP.Views.Planeacion_Apoyos;


using GestionPlaneacionDidacticaAPP.ViewModels.Subtemas;
using GestionPlaneacionDidacticaAPP.Views.Subtemas;
using GestionPlaneacionDidacticaAPP.ViewModels.Competencias;
using GestionPlaneacionDidacticaAPP.Views.Competencias;
using GestionPlaneacionDidacticaAPP.ViewModels.ActividadEnseñanza;
using GestionPlaneacionDidacticaAPP.Views.ActividadEnseñanza;

namespace GestionPlaneacionDidacticaAPP.Services.Navegacion
{
    public class FicSrvNavigationInventario : IFicSrvNavigationInventario
    {
        private IDictionary<Type, Type> FicViewModelRouting = new Dictionary<Type, Type>()
        {
            //AQUI SE HACE UNA UNION ENTRE LA VM Y VI DE CADA VIEW DE LA APP
            {typeof(FicVmPlaneacion),typeof(FicViPlaneacion) },
            {typeof(FicVmPlaneacionInsert),typeof(FicViPlaneacionInsert) },

            {typeof(FicVmSubtemaList),typeof(FicViSubtemasList)},
            {typeof(FicVmSubtemaInsert),typeof(FicViSubtemaInsert)},
            {typeof(FicVmSubtemaView),typeof(FicViSubtemaView)},
            {typeof(FicVmSubtemasUpdate),typeof(FicViSubtemaUpdate)},


            {typeof(FicVmPlaneacionView),typeof(FicViPlaneacionView) },
            {typeof(FicVmPlaneacionUpdate),typeof(FicViPlaneacionUpdate) },
            {typeof(FicVmPlaneacionGuardarComo),typeof(FicViPlaneacionGuardarComo) },

            {typeof(FicVmTemasList),typeof(ViTemasList) },
            {typeof(FicVmTemasInsert),typeof(ViTemasInsert) },
            {typeof(FicVmTemasView),typeof(ViTemasView) },
            {typeof(FicVmTemasUpdate),typeof(ViTemasUpdate) },

            {typeof(FicVmEnseñanzaList),typeof(FicViEnseñanzaList) },
            {typeof(FicVmEnseñanzaInsert),typeof(FicViEnseñanzaInsert) },
            {typeof(FicVmEnseñanzaUpdate),typeof(FicViEnseñanzaUpdate) },
            {typeof(FicVmEnseñanzaDetalle),typeof(FicViEnseñanzaDetalle) },

            {typeof(FicVmActividadEnseñanza),typeof(FicViActividadEnseñanza) },
            {typeof(FicVmActividadEnseñanzaInsert),typeof(FicViActividadEnseñanzaInsert) },
            {typeof(FicVmActividadEnseñanzaUpdate), typeof(FicViActividadEnseñanzaUpdate) },
            {typeof(FicVmActividadEnseñanzaDetalle), typeof(FicViActividadEnseñanzaDetalle) },

            {typeof(FicVmAprendizajesList),typeof(FicViAprendizajesList) },
            {typeof(FicVmAprendizajesInsert),typeof(FicViAprendizajesInsert) },
            {typeof(FicVmAprendizajesUpdate),typeof(FicViAprendizajesUpdate) },
            {typeof(FicVmAprendizajesView),typeof(FicViAprendizajesView) },

            {typeof(FicVmCriteriosEvaluacionList),typeof(ViCriteriosEvaluacionList) },
            {typeof(FicVmCriteriosEvaluacionInsert),typeof(ViCriteriosEvaluacionInsert) },
            {typeof(FicVmCriteriosEvaluacionView),typeof(ViCriteriosEvaluacionView) },
            {typeof(FicVmCriteriosEvaluacionUpdate),typeof(ViCriteriosEvaluacionUpdate) },

            {typeof(VmApoyosDidacticosList),typeof(ViApoyosDidacticos) },
            {typeof(FicVmApoyosDidacticosUpdate),typeof(FicViApoyosDidacticosUpdate) },
            {typeof(FicVmApoyosDidacticosInsert),typeof(FicViApoyosDidacticosInsert) },
            {typeof(FicVmApoyosDidacticosView),typeof(FicViApoyosDidacticosView) },

            { typeof(FicVmCompetenciasList),typeof(FicViCompetencias)},
            { typeof(FicVmCompetenciasInsert),typeof(FicViCompetenciasInsert) },
            { typeof(FicVmCompetenciasView),typeof(FicViCompetenciasView) },
            { typeof(FicVmCompetenciasUpdate),typeof(FicViCompetenciasUpdate) },

            { typeof(FicVmPlaneacionApoyosList),typeof(FicViPlaneacionApoyosList) },
            { typeof(FicVmPlaneacionApoyosInsert),typeof(FicViPlaneacionApoyosInsert) },

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
