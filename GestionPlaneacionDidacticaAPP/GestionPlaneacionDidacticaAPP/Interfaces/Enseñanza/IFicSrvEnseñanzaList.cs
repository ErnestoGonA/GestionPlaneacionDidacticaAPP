﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Interfaces.Enseñanza
{
    public interface IFicSrvEnseñanzaList
    {
        Task<IEnumerable<eva_planeacion_enseñanza>> FicMetGetListEnseñanza();
        Task<eva_planeacion> FicMetGetPlaneacion(int id);
        Task<eva_cat_asignaturas> FicMetGetAsignatura(int id);
        Task<eva_planeacion_temas> FicMetGetTema(int id);
        Task<eva_cat_competencias> FicMetGetCompetencia(int id);
        Task<eva_cat_actividades_enseñanza> FicMetGetActividad(int id);
        Task<string> FicMetRemoveEnseñanza(eva_planeacion_enseñanza eva_planeacion_enseñanza);
    }
    public interface IFicSrvEnseñanzaInsert
    {
        Task<string> FicMetAddEnseñanza(eva_planeacion_enseñanza eva_planeacion_enseñanza);
        Task<IEnumerable<eva_planeacion>> FicMetGetPlaneacion();
        Task<IEnumerable<eva_cat_asignaturas>> FicMetGetAsignatura();
        Task<IEnumerable<eva_planeacion_temas>> FicMetGetTema();
        Task<IEnumerable<eva_cat_competencias>> FicMetGetCompetencia();
        Task<IEnumerable<eva_cat_actividades_enseñanza>> FicMetGetActividades();
    }
    public interface IFicSrvEnseñanzaUpdate
    {
        Task<string> FicMetUpdateEnseñanza(eva_planeacion_enseñanza eva_planeacion_enseñanza);
        Task<IEnumerable<eva_cat_actividades_enseñanza>> FicMetGetActividades();
        Task<eva_cat_actividades_enseñanza> FicMetGetActividad(int id);
    }
    public interface IFicSrvEnseñanzaDetalle
    {
        Task<eva_planeacion_enseñanza> FicMetGetEnseñanza(int id);
        Task<eva_cat_asignaturas> FicMetGetAsignatura(int id);
        Task<eva_cat_competencias> FicMetGetCompetencia(int id);
        Task<eva_planeacion> FicMetGetPlaneacion(int id);
        Task<eva_planeacion_temas> FicMetGetTema(int id);
        Task<eva_cat_actividades_enseñanza> FicMetGetActividad(int id);
    }
}
