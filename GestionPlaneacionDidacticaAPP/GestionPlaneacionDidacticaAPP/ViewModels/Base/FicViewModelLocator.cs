using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Asignatura;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Temas;
using GestionPlaneacionDidacticaAPP.Interfaces.CriteriosEvaluacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Apoyos_Didacticos;

using GestionPlaneacionDidacticaAPP.Services.Navegacion;
using GestionPlaneacionDidacticaAPP.Services.Asingatura;
using GestionPlaneacionDidacticaAPP.Services.Planeacion;
using GestionPlaneacionDidacticaAPP.Services.Temas;
using GestionPlaneacionDidacticaAPP.Services.CriteriosEvaluacion;
using GestionPlaneacionDidacticaAPP.Services.Apoyos_Didacticos;

using GestionPlaneacionDidacticaAPP.ViewModels.Planeacion;
using GestionPlaneacionDidacticaAPP.ViewModels.Temas;
using GestionPlaneacionDidacticaAPP.ViewModels.CriteriosEvaluacion;
using GestionPlaneacionDidacticaAPP.ViewModels.Apoyos_Didacticos;
using GestionPlaneacionDidacticaAPP.ViewModels.Enseñanza;
using GestionPlaneacionDidacticaAPP.Services.Enseñanza;
using GestionPlaneacionDidacticaAPP.Interfaces.Enseñanza;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Base
{
    public class FicViewModelLocator
    {
        private static IContainer FicIContainer;

        public FicViewModelLocator()
        {
            //FIC: ContainerBuilder es una clase de la libreria de Autofac para poder ejecutar la interfaz en las diferentes plataformas 
            var FicContainerBuilder = new ContainerBuilder();

            //-------------------------------- VIEW MODELS ------------------------------------------------------
            //FIC: se procede a registrar las ViewModels para que se puedan mandar llamar en cualquier plataforma
            //---------------------------------------------------------------------------------------------------
            //VmTemas

            FicContainerBuilder.RegisterType<VmApoyosDidacticosList>();
            FicContainerBuilder.RegisterType<FicVmApoyosDidacticosUpdate>();
            FicContainerBuilder.RegisterType<FicVmApoyosDidacticosInsert>();
            FicContainerBuilder.RegisterType<FicVmApoyosDidacticosView>();
            FicContainerBuilder.RegisterType<FicVmPlaneacion>();
            FicContainerBuilder.RegisterType<FicVmPlaneacionInsert>();
            FicContainerBuilder.RegisterType<FicVmPlaneacionView>();
            FicContainerBuilder.RegisterType<FicVmPlaneacionUpdate>();
            FicContainerBuilder.RegisterType<FicVmPlaneacionGuardarComo>();
            FicContainerBuilder.RegisterType<FicVmTemasList>();
            FicContainerBuilder.RegisterType<FicVmTemasInsert>();
            FicContainerBuilder.RegisterType<FicVmTemasView>();
            FicContainerBuilder.RegisterType<FicVmTemasUpdate>();

            FicContainerBuilder.RegisterType<FicVmEnseñanzaList>();
            FicContainerBuilder.RegisterType<FicVmEnseñanzaInsert>();
            FicContainerBuilder.RegisterType<FicVmEnseñanzaUpdate>();
            FicContainerBuilder.RegisterType<FicVmEnseñanzaDetalle>();

            FicContainerBuilder.RegisterType<FicVmCriteriosEvaluacionList>();

            //------------------------- INTERFACE SERVICES OF THE VIEW MODELS -----------------------------------
            //FIC: se procede a registrar la interface con la que se comunican las ViewModels con los Servicios 
            //para poder ejecutar las tareas (metodos o funciones, etc) del servicio en cuestion.
            //---------------------------------------------------------------------------------------------------
            FicContainerBuilder.RegisterType<FicSrvNavigationInventario>().As<IFicSrvNavigationInventario>().SingleInstance();

            FicContainerBuilder.RegisterType<FicSrvAsignaturas>().As<IFicSrvAsignatura>().SingleInstance();

            //Temas
            FicContainerBuilder.RegisterType<FicSrvTemas>().As<IFicSrvTemas>().SingleInstance();

            //Criterios
            FicContainerBuilder.RegisterType<FicSrvCriteriosEvaluacion>().As<IFicSrvCriteriosEvaluacion>().SingleInstance();

            FicContainerBuilder.RegisterType<SrvApoyosDidacticos>().As<ISrvApoyosDidacticos>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvPlaneacion>().As<FicISrvPlaneacion>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvPlaneacionInsert>().As<IFicSrvPlaneacionInsert>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvPlaneacionUpdate>().As<IFicSrvPlaneacionUpdate>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvPlaneacionView>().As<IFicSrvPlaneacionView>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvPlaneacionGuardarComo>().As<IFicSrvGuardarComo>().SingleInstance();

            FicContainerBuilder.RegisterType<FicSrvEnseñanzaList>().As<IFicSrvEnseñanzaList>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvEnseñanzaInsert>().As<IFicSrvEnseñanzaInsert>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvEnseñanzaUpdate>().As<IFicSrvEnseñanzaUpdate>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvEnseñanzaDetalle>().As<IFicSrvEnseñanzaDetalle>().SingleInstance();


            //FIC: se asigna o se libera el contenedor
            //-------------------------------------------
            if (FicIContainer != null) FicIContainer.Dispose();

            FicIContainer = FicContainerBuilder.Build();
        }//CONSTRUCTOR

        //-------------------- CONTROL DE INVENTARIOS ------------------------
        //FIC: se manda llamar desde el backend de la View de List

        public FicVmTemasList FicVmTemasList
        {
            get { return FicIContainer.Resolve<FicVmTemasList>(); }
        }

        public FicVmTemasInsert FicVmTemasInsert
        {
            get { return FicIContainer.Resolve<FicVmTemasInsert>(); }
        }

        public FicVmTemasView FicVmTemasView
        {
            get { return FicIContainer.Resolve<FicVmTemasView>(); }
        }

        public FicVmTemasUpdate FicVmTemasUpdate
        {
            get { return FicIContainer.Resolve<FicVmTemasUpdate>(); }
        }

        public FicVmCriteriosEvaluacionList FicVmCriteriosEvaluacionList
        {
            get { return FicIContainer.Resolve<FicVmCriteriosEvaluacionList>(); }
        }

        public VmApoyosDidacticosList VmApoyosDidacticosList
        {
            get { return FicIContainer.Resolve<VmApoyosDidacticosList>(); }
        }

        public FicVmApoyosDidacticosUpdate FicVmApoyosDidacticosUpdate
        {
            get { return FicIContainer.Resolve<FicVmApoyosDidacticosUpdate>(); }
        }

        public FicVmApoyosDidacticosInsert FicVmApoyosDidacticosInsert
        {
            get { return FicIContainer.Resolve<FicVmApoyosDidacticosInsert>(); }
        }

        public FicVmApoyosDidacticosView FicVmApoyosDidacticosView
        {
            get { return FicIContainer.Resolve<FicVmApoyosDidacticosView>(); }
        }

        public FicVmPlaneacion FicVmPlaneacion
        {
            get { return FicIContainer.Resolve<FicVmPlaneacion>(); }
        }

        public FicVmPlaneacionInsert FicVmPlaneacionInsert
        {
            get { return FicIContainer.Resolve<FicVmPlaneacionInsert>(); }
        }
        public FicVmPlaneacionView FicVmPlaneacionView
        {
            get { return FicIContainer.Resolve<FicVmPlaneacionView>(); }
        }
        public FicVmPlaneacionUpdate FicVmPlaneacionUpdate
        {
            get { return FicIContainer.Resolve<FicVmPlaneacionUpdate>(); }
        }
        public FicVmPlaneacionGuardarComo FicVmPlaneacionGuardarComo
        {
            get { return FicIContainer.Resolve<FicVmPlaneacionGuardarComo>(); }
        }
        public FicVmEnseñanzaList FicVmEnseñanzaList
        {
            get { return FicIContainer.Resolve<FicVmEnseñanzaList>(); }
        }
        public FicVmEnseñanzaInsert FicVmEnseñanzaInsert
        {
            get { return FicIContainer.Resolve<FicVmEnseñanzaInsert>(); }
        }
        public FicVmEnseñanzaUpdate FicVmEnseñanzaUpdate
        {
            get { return FicIContainer.Resolve<FicVmEnseñanzaUpdate>(); }
        }
        public FicVmEnseñanzaDetalle FicVmEnseñanzaDetalle
        {
            get { return FicIContainer.Resolve<FicVmEnseñanzaDetalle>(); }
        }

    }//CLASS
}//NAMESPACE
