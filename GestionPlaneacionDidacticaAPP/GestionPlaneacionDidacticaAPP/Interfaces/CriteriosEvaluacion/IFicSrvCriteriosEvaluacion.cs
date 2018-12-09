using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Interfaces.CriteriosEvaluacion
{
    public interface IFicSrvCriteriosEvaluacion
    {
        Task<IEnumerable<eva_planeacion_criterios_evalua>> MetGetListCriteriosEvaluacion();
        Task<IEnumerable<eva_planeacion_criterios_evalua>> MetGetListCriteriosEvaluacionCompetencia(short IdCompetencia);
        Task<string> InsertCriterioEvaluacion(eva_planeacion_criterios_evalua CriterioEvaluacion);
        Task<string> UpdateCriterioEvaluacion(eva_planeacion_criterios_evalua CriterioEvaluacion);
        Task<string> DeleteCriterioEvaluacion(eva_planeacion_criterios_evalua CriterioEvaluacion);
    }
}
