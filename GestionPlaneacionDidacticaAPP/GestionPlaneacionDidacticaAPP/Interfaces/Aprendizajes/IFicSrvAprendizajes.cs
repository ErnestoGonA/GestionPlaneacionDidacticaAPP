using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Interfaces.Aprendizajes
{
    public interface IFicSrvAprendizajes
    {
        Task<IEnumerable<eva_planeacion_aprendizaje>> MetGetListAprendizajes();
        Task<IEnumerable<eva_planeacion_aprendizaje>> MetGetListAprendizajes(eva_planeacion_temas_competencias eptc);
        Task<string> InsertAprendizaje(eva_planeacion_aprendizaje Aprendizaje);
        Task<string> UpdateAprendizaje(eva_planeacion_aprendizaje Aprendizaje);
        Task<string> DeleteAprendizaje(eva_planeacion_aprendizaje Aprendizaje);
    }
}
