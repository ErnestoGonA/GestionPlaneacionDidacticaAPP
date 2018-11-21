
//using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
//using GestionPlaneacionDidacticaAPP.Interfaces.CatGenerales;
//using GestionPlaneacionDidacticaAPP.Services.Navegacion;
//using GestionPlaneacionDidacticaAPP.Services.CatGenerales;
//using GestionPlaneacionDidacticaAPP.ViewModels;
//using GestionPlaneacionDidacticaAPP.Views.CatGenerales;

using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

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
            ///////////FicContainerBuilder.RegisterType<FicVmCatEdificiosList>();
            //FicContainerBuilder.RegisterType<FicVmCatEdificiosList>();
            //FicContainerBuilder.RegisterType<FicVmCatEdificiosInsert>();
            //FicContainerBuilder.RegisterType<FicVmCatEdificiosUpdate>();
            //FicContainerBuilder.RegisterType<FicVmCatEdificiosView>();
            //FicContainerBuilder.RegisterType<FicVmCatEdificiosImportarExportar>();

            ////FicContainerBuilder.RegisterType<FicVmInventariosList>();
            ////FicContainerBuilder.RegisterType<FicVmInventarioConteoList>();
            ////FicContainerBuilder.RegisterType<FicVmInventarioConteosItem>();
            ////FicContainerBuilder.RegisterType<FicVmInventarioAcumuladoList>();
            ////FicContainerBuilder.RegisterType<FicVmImportarWebApi>();
            ////FicContainerBuilder.RegisterType<FicVmExportarWebApi>();
            //------------------------- INTERFACE SERVICES OF THE VIEW MODELS -----------------------------------
            //FIC: se procede a registrar la interface con la que se comunican las ViewModels con los Servicios 
            //para poder ejecutar las tareas (metodos o funciones, etc) del servicio en cuestion.
            //---------------------------------------------------------------------------------------------------
            //FicContainerBuilder.RegisterType<FicSrvNavigationInventario>().As<IFicSrvNavigationInventario>().SingleInstance();
            //FicContainerBuilder.RegisterType<FicSrvCatEdificiosList>().As<IFicSrvCatEdificiosList>().SingleInstance();
            //FicContainerBuilder.RegisterType<FicSrvCatEdificiosInsert>().As<IFicSrvCatEdificiosInsert>().SingleInstance();
            //FicContainerBuilder.RegisterType<FicSrvCatEdificiosUpdate>().As<IFicSrvCatEdificiosUpdate>().SingleInstance();
            //FicContainerBuilder.RegisterType<FicSrvCatEdificiosImportarExportar>().As<IFicSrvCatEdificiosImportarExportar>().SingleInstance();
            ////FicContainerBuilder.RegisterType<FicSrvInventariosList>().As<IFicSrvInventariosList>().SingleInstance();
            ////FicContainerBuilder.RegisterType<FicSrvInventariosConteosItem>().As<IFicSrvInventariosConteosItem>().SingleInstance();
            ////FicContainerBuilder.RegisterType<FicSrvInventariosConteoList>().As<IFicSrvInventariosConteoList>().SingleInstance();
            ////FicContainerBuilder.RegisterType<FicSrvInventarioAcumuladoList>().As<IFicSrvInventarioAcumuladoList>().SingleInstance();
            ////FicContainerBuilder.RegisterType<FicSrvImportarWebApi>().As<IFicSrvImportarWebApi>().SingleInstance();
            ////FicContainerBuilder.RegisterType<FicSrvExportarWebApi>().As<IFicSrvExportarWebApi>().SingleInstance();

            //FIC: se asigna o se libera el contenedor
            //-------------------------------------------
            if (FicIContainer != null) FicIContainer.Dispose();

            FicIContainer = FicContainerBuilder.Build();
        }//CONSTRUCTOR

        //-------------------- CONTROL DE INVENTARIOS ------------------------
        //FIC: se manda llamar desde el backend de la View de List

        //public FicVmCatEdificiosList FicVmCatEdificiosList
        //{
        //    get { return FicIContainer.Resolve<FicVmCatEdificiosList>(); }
        //}

        //public FicVmCatEdificiosInsert FicVmCatEdificiosInsert
        //{
        //    get { return FicIContainer.Resolve<FicVmCatEdificiosInsert>(); }
        //}

        //public FicVmCatEdificiosUpdate FicVmCatEdificiosUpdate
        //{
        //    get { return FicIContainer.Resolve<FicVmCatEdificiosUpdate>(); }
        //}

        //public FicVmCatEdificiosView FicVmCatEdificiosView
        //{
        //    get { return FicIContainer.Resolve<FicVmCatEdificiosView>(); }
        //}

        //public FicVmCatEdificiosImportarExportar FicVmCatEdificiosImportarExportar
        //{
        //    get { return FicIContainer.Resolve<FicVmCatEdificiosImportarExportar>(); }
        //}

        //Agregar el de nuevo, agregar el de eliminar, agregar el de actualizar, agregar detralle


        ////public FicVmInventariosList FicVmInventariosList
        ////{
        ////    get { return FicIContainer.Resolve<FicVmInventariosList>(); }
        ////}

        ////public FicVmInventarioConteoList FicVmInventarioConteoList
        ////{
        ////    get { return FicIContainer.Resolve<FicVmInventarioConteoList>(); }
        ////}

        ////public FicVmInventarioConteosItem FicVmInventarioConteosItem
        ////{
        ////    get { return FicIContainer.Resolve<FicVmInventarioConteosItem>(); }
        ////}

        ////public FicVmInventarioAcumuladoList FicVmInventarioAcumuladoList
        ////{
        ////    get { return FicIContainer.Resolve<FicVmInventarioAcumuladoList>(); }
        ////}

        ////public FicVmImportarWebApi FicVmImportarWebApi
        ////{
        ////    get { return FicIContainer.Resolve<FicVmImportarWebApi>(); }
        ////}

        ////public FicVmExportarWebApi FicVmExportarWebApi
        ////{
        ////    get { return FicIContainer.Resolve<FicVmExportarWebApi>(); }
        ////}

    }//CLASS
}//NAMESPACE
