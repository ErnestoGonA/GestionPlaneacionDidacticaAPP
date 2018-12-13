using GestionPlaneacionDidacticaAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionPlaneacionDidacticaAPP.Interfaces.ActividadEnseñanza
{
    public interface IFicSrvActividadEnseñanza
    {
        Task<IEnumerable<eva_cat_actividades_enseñanza>> FicMetGetListActividadEnseñanza();
        Task<eva_cat_actividades_enseñanza> FicMetGetActividadEnseñanza(int id);
        Task<string> FicMetAddActividadEnseñanza(eva_cat_actividades_enseñanza eva_cat_actividades_enseñanza);
        Task<string> FicMetUpdateEnseñanza(eva_cat_actividades_enseñanza eva_cat_actividades_enseñanza);
        Task<string> FicMetRemoveEnseñanza(eva_cat_actividades_enseñanza eva_cat_actividades_enseñanza);
    }
}
