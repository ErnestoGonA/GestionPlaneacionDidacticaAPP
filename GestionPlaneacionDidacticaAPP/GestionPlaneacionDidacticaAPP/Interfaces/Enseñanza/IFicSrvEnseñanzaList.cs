using System;
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
        Task<string> FicMetRemoveEnseñanza();
    }
}
