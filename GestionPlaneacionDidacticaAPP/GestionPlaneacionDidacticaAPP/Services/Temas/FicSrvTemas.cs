using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Temas;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Services.Temas
{
    public class FicSrvTemas : IFicSrvTemas
    {

        private readonly DBContext DBLoContext;

        public FicSrvTemas()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        //List all temas
        public async Task<IEnumerable<eva_planeacion_temas>> MetGetListTemas()
        {
            return await (from tema in DBLoContext.eva_planeacion_temas select tema).AsNoTracking().ToListAsync();  
        }

        //List temas of a planeacion
        public async Task<IEnumerable<eva_planeacion_temas>> MetGetListTemasPlaneacion(eva_planeacion Planeacion)
        {
            return await(from tema in DBLoContext.eva_planeacion_temas
                         where tema.IdAsignatura == Planeacion.IdAsignatura
                         where tema.IdPlaneacion== Planeacion.IdPlaneacion
                         select tema).AsNoTracking().ToListAsync();
        }

        public async Task<string> InsertTema(eva_planeacion_temas Tema)
        {
            try
            {

                var temas =await  (from tema in DBLoContext.eva_planeacion_temas
                                   where tema.IdAsignatura==Tema.IdAsignatura
                                   where tema.IdPlaneacion == Tema.IdPlaneacion
                                   select tema).ToListAsync();

                short maxId = 0;
                if (temas.Count()>0)
                {
                    maxId = (from tema in DBLoContext.eva_planeacion_temas
                             where tema.IdAsignatura == Tema.IdAsignatura
                             where tema.IdPlaneacion == Tema.IdPlaneacion
                             select tema.IdTema).Max();
                }

                Tema.IdTema = ++maxId;

                await DBLoContext.AddAsync(Tema);
                var res =  await DBLoContext.SaveChangesAsync() > 0 ? "Ok" : "Error al insertar tema";
                DBLoContext.Entry(Tema).State = EntityState.Detached;
                return res;
            }
            catch(Exception e)
            {
                return e.Message.ToString();
            }
        }

        public async Task<string> UpdateTema(eva_planeacion_temas Tema)
        {
            try
            {
                DBLoContext.Entry(Tema).State = EntityState.Modified;
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "Error al actualizar tema";
                DBLoContext.Entry(Tema).State = EntityState.Detached;
                return res;
            }
            catch(Exception e)
            {
                return e.Message.ToString();
            }
        }

        public async Task<string> DeleteTema(eva_planeacion_temas Tema)
        {
            // TODO: Delete subtema, competencia, aprendizaje, enseñanza, criterios
            List<eva_planeacion_subtemas> subtemas = await (from subtema in DBLoContext.eva_planeacion_subtemas
                                  where subtema.IdAsignatura == Tema.IdAsignatura
                                  where subtema.IdPlaneacion == Tema.IdPlaneacion
                                  where subtema.IdTema == Tema.IdTema
                                  select subtema).AsNoTracking().ToListAsync();
            foreach(eva_planeacion_subtemas subtema in subtemas)
            {
                DBLoContext.eva_planeacion_subtemas.Remove(subtema);
            }
            List<eva_planeacion_criterios_evalua> criterios = await (from criterio in DBLoContext.eva_planeacion_criterios_evalua
                                                            where criterio.IdAsignatura == Tema.IdAsignatura
                                                            where criterio.IdPlaneacion == Tema.IdPlaneacion
                                                            where criterio.IdTema == Tema.IdTema
                                                            select criterio).AsNoTracking().ToListAsync();
            foreach (eva_planeacion_criterios_evalua criterio in criterios)
            {
                DBLoContext.eva_planeacion_criterios_evalua.Remove(criterio);
            }

            List<eva_planeacion_enseñanza> enseñanzas = await (from enseñanza in DBLoContext.eva_planeacion_enseñanza
                                                                     where enseñanza.IdAsignatura == Tema.IdAsignatura
                                                                     where enseñanza.IdPlaneacion == Tema.IdPlaneacion
                                                                     where enseñanza.IdTema == Tema.IdTema
                                                                     select enseñanza).AsNoTracking().ToListAsync();
            foreach (eva_planeacion_enseñanza enseñanza in enseñanzas)
            {
                DBLoContext.eva_planeacion_enseñanza.Remove(enseñanza);
            }
            List<eva_planeacion_aprendizaje> aprendizajes = await (from aprendizaje in DBLoContext.eva_planeacion_aprendizaje
                                                                     where aprendizaje.IdAsignatura == Tema.IdAsignatura
                                                                     where aprendizaje.IdPlaneacion == Tema.IdPlaneacion
                                                                     where aprendizaje.IdTema == Tema.IdTema
                                                                     select aprendizaje).AsNoTracking().ToListAsync();
            foreach (eva_planeacion_aprendizaje aprendizaje in aprendizajes)
            {
                DBLoContext.eva_planeacion_aprendizaje.Remove(aprendizaje);
            }
            List<eva_planeacion_temas_competencias> competencias = await (from competencia in DBLoContext.eva_planeacion_temas_competencias
                                                                     where competencia.IdAsignatura == Tema.IdAsignatura
                                                                     where competencia.IdPlaneacion == Tema.IdPlaneacion
                                                                     where competencia.IdTema == Tema.IdTema
                                                                     select competencia).AsNoTracking().ToListAsync();
            foreach (eva_planeacion_temas_competencias competencia in competencias)
            {
                DBLoContext.eva_planeacion_temas_competencias.Remove(competencia);
            } 

            DBLoContext.eva_planeacion_temas.Remove(Tema);
            return await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "Error al eliminar tema";
        }
        
    }
}
