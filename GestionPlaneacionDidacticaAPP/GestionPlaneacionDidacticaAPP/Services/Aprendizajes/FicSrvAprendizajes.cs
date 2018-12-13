using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Aprendizajes;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Services.Aprendizajes
{
    public class FicSrvAprendizajes : IFicSrvAprendizajes
    {

        private readonly DBContext DBLoContext;

        public FicSrvAprendizajes()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }


        public async Task<string> DeleteAprendizaje(eva_planeacion_aprendizaje Aprendizaje)
        {
            DBLoContext.Remove(Aprendizaje);
            return await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL ELIMINAR APRENDIZJAE";
        }

        public async Task<string> InsertAprendizaje(eva_planeacion_aprendizaje Aprendizaje)
        {
            var aprendizajes = await (from aprendizaje in DBLoContext.eva_planeacion_aprendizaje
                                      where aprendizaje.IdPlaneacion == Aprendizaje.IdPlaneacion
                                      where aprendizaje.IdAsignatura == Aprendizaje.IdAsignatura
                                      where aprendizaje.IdTema == Aprendizaje.IdTema
                                      where aprendizaje.IdCompetencia == Aprendizaje.IdCompetencia
                                      where aprendizaje.IdActividadAprendizaje == Aprendizaje.IdActividadAprendizaje
                                      select aprendizaje).AsNoTracking().ToListAsync();

            if (aprendizajes.Count() > 0)
            {
                return "OK";
            }
            else
            {
                await DBLoContext.AddAsync(Aprendizaje);
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL INSERTAR LA COMPETENCIA";
                DBLoContext.Entry(Aprendizaje).State = EntityState.Detached;
                return res;

            }
        }

        public async Task<List<string>> MetGetActividadesAprendizaje()
        {
            return await (from actividad in DBLoContext.eva_cat_actividades_aprendizaje select actividad.DesActividadAprendizaje).AsNoTracking().ToListAsync();
        }

        public Task<IEnumerable<eva_planeacion_aprendizaje>> MetGetListAprendizajes()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<eva_planeacion_aprendizaje>> MetGetListAprendizajes(eva_planeacion_temas_competencias eptc)
        {
            return await (from aprendizaje in DBLoContext.eva_planeacion_aprendizaje
                          where aprendizaje.IdAsignatura == eptc.IdAsignatura
                         where aprendizaje.IdPlaneacion == eptc.IdPlaneacion
                         where aprendizaje.IdTema == eptc.IdTema
                         where aprendizaje.IdCompetencia == eptc.IdCompetencia
                         select aprendizaje).AsNoTracking().ToListAsync();
        }

        public Task<string> UpdateAprendizaje(eva_planeacion_aprendizaje Aprendizaje)
        {
            throw new NotImplementedException();
        }
    }
}
