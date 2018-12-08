using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Temas;
using GestionPlaneacionDidacticaAPP.Services.Navegacion;
using GestionPlaneacionDidacticaAPP.Services.Temas;
using GestionPlaneacionDidacticaAPP.ViewModels.Temas;
using GestionPlaneacionDidacticaAPP.Views.Temas;
using GestionPlaneacionDidacticaAPP.ViewModels.Apoyos_Didacticos;
using GestionPlaneacionDidacticaAPP.Interfaces.Asignatura;
using GestionPlaneacionDidacticaAPP.Services.Asingatura;
using GestionPlaneacionDidacticaAPP.Interfaces.Apoyos_Didacticos;
using GestionPlaneacionDidacticaAPP.Services.Apoyos_Didacticos;
using GestionPlaneacionDidacticaAPP.ViewModels.Planeacion;
using GestionPlaneacionDidacticaAPP.Services.Planeacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion;

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
            FicContainerBuilder.RegisterType<FicVmPlaneacion>();
            FicContainerBuilder.RegisterType<FicVmPlaneacionInsert>();
            FicContainerBuilder.RegisterType<FicVmPlaneacionView>();
            FicContainerBuilder.RegisterType<FicVmPlaneacionUpdate>();
            FicContainerBuilder.RegisterType<FicVmTemasList>();
            FicContainerBuilder.RegisterType<FicVmTemasInsert>();
            FicContainerBuilder.RegisterType<FicVmTemasView>();
            FicContainerBuilder.RegisterType<FicVmTemasUpdate>();

            ///////////FicContainerBuilder.RegisterType<FicVmCatEdificiosList>();
            //FicContainerBuilder.RegisterType<FicVmCatEdificiosList>();
            //FicContainerBuilder.RegisterType<FicVmCatEdificiosInsert>();
            //FicContainerBuilder.RegisterType<FicVmCatEdificiosUpdate>();
            //FicContainerBuilder.RegisterType<FicVmCatEdificiosView>();
            //FicContainerBuilder.RegisterType<FicVmCatEdificiosImportarExportar>();

            //------------------------- INTERFACE SERVICES OF THE VIEW MODELS -----------------------------------
            //FIC: se procede a registrar la interface con la que se comunican las ViewModels con los Servicios 
            //para poder ejecutar las tareas (metodos o funciones, etc) del servicio en cuestion.
            //---------------------------------------------------------------------------------------------------
            FicContainerBuilder.RegisterType<FicSrvNavigationInventario>().As<IFicSrvNavigationInventario>().SingleInstance();

            FicContainerBuilder.RegisterType<FicSrvAsignaturas>().As<IFicSrvAsignatura>().SingleInstance();

            //Temas
            FicContainerBuilder.RegisterType<FicSrvTemas>().As<IFicSrvTemas>().SingleInstance();

            FicContainerBuilder.RegisterType<SrvApoyosDidacticos>().As<ISrvApoyosDidacticos>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvPlaneacion>().As<FicISrvPlaneacion>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvPlaneacionInsert>().As<IFicSrvPlaneacionInsert>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvPlaneacionUpdate>().As<IFicSrvPlaneacionUpdate>().SingleInstance();

           
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

        public VmApoyosDidacticosList VmApoyosDidacticosList
        {
            get { return FicIContainer.Resolve<VmApoyosDidacticosList>(); }
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

    }//CLASS
}//NAMESPACE
