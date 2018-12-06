using GestionPlaneacionDidacticaAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionPlaneacionDidacticaAPP.Interfaces.Apredizaje
{
    public interface IFicSrvAprendizaje
    {
        Task<IEnumerable<eva_planeacion_aprendizaje>> MetGetListAprendizaje();
        Task<string> InsertAprendizaje(eva_planeacion_aprendizaje aprendizaje);
        Task<string> UpdateAprendizaje(eva_planeacion_aprendizaje aprendizaje);
        Task<string> RemoveAprendizaje(eva_planeacion_aprendizaje aprendizaje);
    }
}
