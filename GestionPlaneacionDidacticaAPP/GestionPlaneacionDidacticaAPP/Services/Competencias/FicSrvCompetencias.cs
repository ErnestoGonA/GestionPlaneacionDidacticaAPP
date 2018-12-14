using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Competencias;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Services.Competencias
{
    public class FicSrvCompetencias : IFicSrvCompetencias
    {
        private readonly DBContext DBLoContext;

        public FicSrvCompetencias()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        public async Task<string> DeleteCompetencia(eva_planeacion_temas_competencias Compe)
        {

            // TODO:  competencia, aprendizaje, enseñanza, criterios

            List<eva_planeacion_criterios_evalua> criterios = await (from criterio in DBLoContext.eva_planeacion_criterios_evalua
                                                                     where criterio.IdAsignatura == Compe.IdAsignatura
                                                                     where criterio.IdPlaneacion == Compe.IdPlaneacion
                                                                     where criterio.IdTema == Compe.IdTema
                                                                     where criterio.IdCompetencia == Compe.IdCompetencia
                                                                     select criterio).AsNoTracking().ToListAsync();
            foreach (eva_planeacion_criterios_evalua criterio in criterios)
            {
                DBLoContext.eva_planeacion_criterios_evalua.Remove(criterio);
            }

            List<eva_planeacion_enseñanza> enseñanzas = await (from enseñanza in DBLoContext.eva_planeacion_enseñanza
                                                               where enseñanza.IdAsignatura == Compe.IdAsignatura
                                                               where enseñanza.IdPlaneacion == Compe.IdPlaneacion
                                                               where enseñanza.IdTema == Compe.IdTema
                                                               where enseñanza.IdCompetencia == Compe.IdCompetencia
                                                               select enseñanza).AsNoTracking().ToListAsync();
            foreach (eva_planeacion_enseñanza enseñanza in enseñanzas)
            {
                DBLoContext.eva_planeacion_enseñanza.Remove(enseñanza);
            }
            List<eva_planeacion_aprendizaje> aprendizajes = await (from aprendizaje in DBLoContext.eva_planeacion_aprendizaje
                                                                   where aprendizaje.IdAsignatura == Compe.IdAsignatura
                                                                   where aprendizaje.IdPlaneacion == Compe.IdPlaneacion
                                                                   where aprendizaje.IdTema == Compe.IdTema
                                                                   where aprendizaje.IdCompetencia == Compe.IdCompetencia
                                                                   select aprendizaje).AsNoTracking().ToListAsync();
            foreach (eva_planeacion_aprendizaje aprendizaje in aprendizajes)
            {
                DBLoContext.eva_planeacion_aprendizaje.Remove(aprendizaje);
            }

            DBLoContext.Remove(Compe);
            return await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL ELIMINAR LA COMPETENCIA";
        }

        public async Task<IEnumerable<eva_cat_competencias>> GetListCompetencias()
        {
            return await(from competencias in DBLoContext.eva_cat_competencias select competencias).AsNoTracking().ToListAsync();
        }

        public async Task<string> InsertCompetencia(eva_planeacion_temas_competencias Compe)
        {
            try
            {
                var competenciasid = await (from compe in DBLoContext.eva_planeacion_temas_competencias
                                            where compe.IdPlaneacion == Compe.IdPlaneacion
                                            where compe.IdAsignatura == Compe.IdAsignatura
                                            where compe.IdTema == Compe.IdTema
                                            where compe.IdCompetencia == Compe.IdCompetencia
                                            select compe).AsNoTracking().ToListAsync();

                if (competenciasid.Count() > 0)
                {
                    return "OK";
                }
                else
                {
                    await DBLoContext.AddAsync(Compe);
                    var res = await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL INSERTAR LA COMPETENCIA";
                    DBLoContext.Entry(Compe).State = EntityState.Detached;
                    return res;

                }

                //await DBLoContext.AddAsync(Compe);
                //var res = await DBLoContext.SaveChangesAsync() > 0 ? "Ok" : "ERROR AL INSERTAR LA COMPETENCIA";
                //DBLoContext.Entry(Compe).State = EntityState.Detached;
                //return res;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        //Lista todos los apoyos_didacticos
        public async Task<IEnumerable<eva_planeacion_temas_competencias>> MetGetListCompetencias()
        {
            return await (from compe in DBLoContext.eva_planeacion_temas_competencias select compe).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<eva_planeacion_temas_competencias>> MetGetListCompetenciasTemasPlaneacion(eva_planeacion_temas Tema)
        {
            return await (from compe in DBLoContext.eva_planeacion_temas_competencias
                         where compe.IdPlaneacion == Tema.IdPlaneacion
                         where compe.IdAsignatura == Tema.IdAsignatura
                         where compe.IdTema == Tema.IdTema
                         select compe).AsNoTracking().ToListAsync();
        }

        public async Task<string> UpdateCompetencia(eva_planeacion_temas_competencias Compe)
        {
            try
            {
                DBLoContext.Update(Compe);
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL ACTUALIZAR LA COMPETENCIA";
                DBLoContext.Entry(Compe).State = EntityState.Detached;
                return res;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
