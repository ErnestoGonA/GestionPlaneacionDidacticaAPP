using GestionPlaneacionDidacticaAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionPlaneacionDidacticaAPP.Interfaces.Fuentes
{
    public interface IFicSrvFuentes
    {
        Task<IEnumerable<eva_planeacion_fuentes>> MetGetListFuentes();
        Task<IEnumerable<eva_planeacion_fuentes>> MetGetListFuentesPlaneacion(eva_planeacion Planeacion);
        Task<eva_cat_fuentes_bibliograficas> GetFuenteB(short IdFuente);
        Task<string> InsertFuente(eva_planeacion_fuentes Fuente);
        Task<string> UpdateFuente(eva_planeacion_fuentes Fuente);
        Task<string> DeleteFuente(eva_planeacion_fuentes Fuente);
        Task<IEnumerable<eva_cat_fuentes_bibliograficas>> FicMetGetListFuentesB();
    }
}
