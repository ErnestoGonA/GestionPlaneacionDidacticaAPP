﻿using Autofac;
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
using GestionPlaneacionDidacticaAPP.Services.Subtemas;
using GestionPlaneacionDidacticaAPP.Interfaces.Subtemas;
using GestionPlaneacionDidacticaAPP.ViewModels.Subtemas;

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
            FicContainerBuilder.RegisterType<FicVmSubtemaList>();
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
            FicContainerBuilder.RegisterType<FicSrvSubtemas>().As<IFicSrvSubtemas>().SingleInstance();
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


        public FicVmSubtemaList FicVmSubtemaList
        {
            get { return FicIContainer.Resolve<FicVmSubtemaList>(); }
        }


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
