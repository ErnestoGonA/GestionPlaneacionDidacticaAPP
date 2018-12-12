﻿using Autofac;
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
using GestionPlaneacionDidacticaAPP.Services.Planeacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion;
using GestionPlaneacionDidacticaAPP.Services.Subtemas;
using GestionPlaneacionDidacticaAPP.Interfaces.Subtemas;
using GestionPlaneacionDidacticaAPP.ViewModels.Subtemas;
using GestionPlaneacionDidacticaAPP.ViewModels.Temas;
using GestionPlaneacionDidacticaAPP.ViewModels.CriteriosEvaluacion;
using GestionPlaneacionDidacticaAPP.ViewModels.Apoyos_Didacticos;
using GestionPlaneacionDidacticaAPP.ViewModels.Competencias;
using GestionPlaneacionDidacticaAPP.Interfaces.Competencias;
using GestionPlaneacionDidacticaAPP.Services.Competencias;
using GestionPlaneacionDidacticaAPP.ViewModels.Enseñanza;
using GestionPlaneacionDidacticaAPP.Interfaces.Enseñanza;
using GestionPlaneacionDidacticaAPP.Services.Enseñanza;

using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion_Apoyos;
using GestionPlaneacionDidacticaAPP.Services.Planeacion_Apoyos;
using GestionPlaneacionDidacticaAPP.ViewModels.Planeacion_Apoyos;

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
            FicContainerBuilder.RegisterType<FicVmSubtemaList>();
            FicContainerBuilder.RegisterType<FicVmPlaneacionView>();
            FicContainerBuilder.RegisterType<FicVmPlaneacionUpdate>();
            FicContainerBuilder.RegisterType<FicVmPlaneacionGuardarComo>();
            FicContainerBuilder.RegisterType<FicVmTemasList>();
            FicContainerBuilder.RegisterType<FicVmTemasInsert>();
            FicContainerBuilder.RegisterType<FicVmTemasView>();
            FicContainerBuilder.RegisterType<FicVmTemasUpdate>();

            FicContainerBuilder.RegisterType<FicVmCompetenciasList>();
            FicContainerBuilder.RegisterType<FicVmCompetenciasInsert>();

            FicContainerBuilder.RegisterType<FicVmSubtemaInsert>();
            FicContainerBuilder.RegisterType<FicVmSubtemaView>();
            FicContainerBuilder.RegisterType<FicVmSubtemasUpdate>();


            FicContainerBuilder.RegisterType<FicVmCompetenciasView>();
            FicContainerBuilder.RegisterType<FicVmCompetenciasUpdate>();

            FicContainerBuilder.RegisterType<FicVmPlaneacionApoyosList>();
            FicContainerBuilder.RegisterType<FicVmPlaneacionApoyosInsert>();


            ///////////FicContainerBuilder.RegisterType<FicVmCatEdificiosList>();
            //FicContainerBuilder.RegisterType<FicVmCatEdificiosList>();
            //FicContainerBuilder.RegisterType<FicVmCatEdificiosInsert>();
            //FicContainerBuilder.RegisterType<FicVmCatEdificiosUpdate>();
            //FicContainerBuilder.RegisterType<FicVmCatEdificiosView>();
            //FicContainerBuilder.RegisterType<FicVmCatEdificiosImportarExportar>();

            FicContainerBuilder.RegisterType<FicVmEnseñanzaList>();
            FicContainerBuilder.RegisterType<FicVmEnseñanzaInsert>();
            FicContainerBuilder.RegisterType<FicVmEnseñanzaUpdate>();
            FicContainerBuilder.RegisterType<FicVmEnseñanzaDetalle>();

            FicContainerBuilder.RegisterType<FicVmCriteriosEvaluacionList>();
            FicContainerBuilder.RegisterType<FicVmCriteriosEvaluacionInsert>();
            FicContainerBuilder.RegisterType<FicVmCriteriosEvaluacionView>();
            FicContainerBuilder.RegisterType<FicVmCriteriosEvaluacionUpdate>();

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
            //apoyos didacticos
            FicContainerBuilder.RegisterType<SrvApoyosDidacticos>().As<ISrvApoyosDidacticos>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvPlaneacion>().As<FicISrvPlaneacion>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvPlaneacionInsert>().As<IFicSrvPlaneacionInsert>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvSubtemas>().As<IFicSrvSubtemas>().SingleInstance();
            //competencias
            FicContainerBuilder.RegisterType<FicSrvCompetencias>().As<IFicSrvCompetencias>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvPlaneacionApoyos>().As<IFicSrvPlaneacionApoyos>().SingleInstance();
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

        public FicVmCriteriosEvaluacionInsert FicVmCriteriosEvaluacionInsert
        {
            get { return FicIContainer.Resolve<FicVmCriteriosEvaluacionInsert>(); }
        }

        public FicVmCriteriosEvaluacionView FicVmCriteriosEvaluacionView
        {
            get { return FicIContainer.Resolve<FicVmCriteriosEvaluacionView>(); }
        }

        public FicVmCriteriosEvaluacionUpdate FicVmCriteriosEvaluacionUpdate
        {
            get { return FicIContainer.Resolve<FicVmCriteriosEvaluacionUpdate>(); }
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


        public FicVmSubtemaList FicVmSubtemaList
        {
            get { return FicIContainer.Resolve<FicVmSubtemaList>(); }
        }

        public FicVmCompetenciasList FicVmCompetenciasList
        {
            get { return FicIContainer.Resolve<FicVmCompetenciasList>();  }
        }

        public FicVmCompetenciasInsert FicVmCompetenciasInsert
        {
            get { return FicIContainer.Resolve<FicVmCompetenciasInsert>(); }
        }


        public FicVmSubtemaInsert FicVmSubtemaInsert
        {
            get { return FicIContainer.Resolve<FicVmSubtemaInsert>(); }
        }

        public FicVmSubtemaView ficVmSubtemaView
        {
            get { return FicIContainer.Resolve<FicVmSubtemaView>(); }
        }


        public FicVmCompetenciasView FicVmCompetenciasView
        {
            get { return FicIContainer.Resolve<FicVmCompetenciasView>(); }
        }

        public FicVmCompetenciasUpdate FicVmCompetenciasUpdate
        {
            get { return FicIContainer.Resolve<FicVmCompetenciasUpdate>(); }
        }

        public FicVmSubtemasUpdate FicVmSubtemasUpdate
        {
            get { return FicIContainer.Resolve<FicVmSubtemasUpdate>(); }
        }

        public FicVmPlaneacionApoyosList FicVmPlaneacionApoyosList
        {
            get { return FicIContainer.Resolve<FicVmPlaneacionApoyosList>(); }
        }

        public FicVmPlaneacionApoyosInsert FicVmPlaneacionApoyosInsert
        {
            get { return FicIContainer.Resolve<FicVmPlaneacionApoyosInsert>(); }
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
