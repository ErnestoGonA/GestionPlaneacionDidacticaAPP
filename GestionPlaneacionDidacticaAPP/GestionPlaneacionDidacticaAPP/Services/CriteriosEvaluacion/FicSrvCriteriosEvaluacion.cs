using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.CriteriosEvaluacion;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Services.CriteriosEvaluacion
{
    public class FicSrvCriteriosEvaluacion : IFicSrvCriteriosEvaluacion
    {

        private readonly DBContext DBLoContext;

        public FicSrvCriteriosEvaluacion()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        public async Task<IEnumerable<eva_planeacion_criterios_evalua>> MetGetListCriteriosEvaluacion()
        {
            return await(from criterio in DBLoContext.eva_planeacion_criterios_evalua select criterio).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<eva_planeacion_criterios_evalua>> MetGetListCriteriosEvaluacionCompetencia(short IdCompetencia)
        {
            return await (from criterio in DBLoContext.eva_planeacion_criterios_evalua where criterio.IdCompetencia==IdCompetencia select criterio).AsNoTracking().ToListAsync();
        }

        public async Task<string> InsertCriterioEvaluacion(eva_planeacion_criterios_evalua CriterioEvaluacion)
        {
            try
            {
                await DBLoContext.AddAsync(CriterioEvaluacion);
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "Ok" : "Error al insertar CriterioEvaluacion";
                DBLoContext.Entry(CriterioEvaluacion).State = EntityState.Detached;
                return res;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public async Task<string> UpdateCriterioEvaluacion(eva_planeacion_criterios_evalua CriterioEvaluacion)
        {
            try
            {
                DBLoContext.Update(CriterioEvaluacion);
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "Error al actualizar CriterioEvaluacion";
                DBLoContext.Entry(CriterioEvaluacion).State = EntityState.Detached;
                return res;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public async Task<string> DeleteCriterioEvaluacion(eva_planeacion_criterios_evalua CriterioEvaluacion)
        {
            DBLoContext.Remove(CriterioEvaluacion);
            return await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "Error al eliminar CriterioEvaluacion";
        }
       
    }
}
