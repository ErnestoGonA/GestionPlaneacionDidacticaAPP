using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Interfaces.Subtemas;
using GestionPlaneacionDidacticaAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GestionPlaneacionDidacticaAPP.Services.Subtemas
{
    public class FicSrvSubtemas : IFicSrvSubtemas
    {
        private readonly DBContext DBLoContext;
        public FicSrvSubtemas()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        //List all subtemas
        public async Task<IEnumerable<eva_planeacion_subtemas>> FicMetGetListSubtemas()
        {
            return await(from subtema in DBLoContext.eva_planeacion_subtemas select subtema).AsNoTracking().ToListAsync();
        }

        //List subtemas of a tema
        public async Task<IEnumerable<eva_planeacion_subtemas>> MetGetListSubtemasTema(eva_planeacion_temas Tema)
        {
            return await (from subtema in DBLoContext.eva_planeacion_subtemas
                          where subtema.IdAsignatura == Tema.IdAsignatura
                          where subtema.IdPlaneacion == Tema.IdPlaneacion
                          where subtema.IdTema == Tema.IdTema
                          select subtema).AsNoTracking().ToListAsync();
        }

        //Insert Subtema
        public async Task<string> InsertSubtema(eva_planeacion_subtemas Subtema)
        {

            try {
                var subtemas = await (from subtema in DBLoContext.eva_planeacion_subtemas
                                      where subtema.IdAsignatura == Subtema.IdAsignatura
                                      where subtema.IdPlaneacion == Subtema.IdPlaneacion
                                      where subtema.IdTema == Subtema.IdTema                                      
                                      select subtema).AsNoTracking().ToListAsync();
                short maxId = 0;
                if (subtemas.Count() > 0) {
                    maxId = (from subtema in DBLoContext.eva_planeacion_subtemas
                             where subtema.IdAsignatura == Subtema.IdAsignatura
                             where subtema.IdPlaneacion == Subtema.IdPlaneacion
                             where subtema.IdTema == Subtema.IdTema
                             select subtema.IdSubtema).Max();
                }

                Subtema.IdSubtema = ++maxId;
                await DBLoContext.AddAsync(Subtema);
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "Ok" : "Error al insertar subtema";
                DBLoContext.Entry(Subtema).State = EntityState.Detached;
                return res;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        //Update subtema
        public async Task<string> UpdateSubtema(eva_planeacion_subtemas Subtema)
        {
            try
            {
                DBLoContext.Entry(Subtema).State = EntityState.Modified;
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "Error al actualizar Subtema";
                DBLoContext.Entry(Subtema).State = EntityState.Detached;
                return res;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }


        //Delete Subtema
        public async Task<string> DeleteSubtema(eva_planeacion_subtemas Subtema)
        {
            DBLoContext.Remove(Subtema);
            return await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "Error al eliminar Subtema";
        }

    }
}
