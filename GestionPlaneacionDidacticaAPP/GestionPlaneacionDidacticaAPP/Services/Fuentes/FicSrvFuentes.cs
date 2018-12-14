using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Fuentes;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace GestionPlaneacionDidacticaAPP.Services.Fuentes
{
    public class FicSrvFuentes : IFicSrvFuentes
    {
        private readonly DBContext DBLoContext;

        public FicSrvFuentes()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }


        //Get list fuentes_biblio
        public async Task<IEnumerable<eva_cat_fuentes_bibliograficas>> FicMetGetListFuentesB()
        {
            return await (from fuente in DBLoContext.eva_cat_fuentes_bibliograficas select fuente).AsNoTracking().ToListAsync();
        }
        //Get eva_cat_fuentes_bibliográficas 
        public async Task<eva_cat_fuentes_bibliograficas> GetFuenteB(short IdFuente)
        {
            return await DBLoContext.eva_cat_fuentes_bibliograficas.FindAsync(IdFuente);
        }

        //List all temas
        public async Task<IEnumerable<eva_planeacion_fuentes>> MetGetListFuentes()
        {
            return await (from fuente in DBLoContext.eva_planeacion_fuentes select fuente).AsNoTracking().ToListAsync();
        }

        //List temas of a planeacion
        public async Task<IEnumerable<eva_planeacion_fuentes>> MetGetListFuentesPlaneacion(eva_planeacion Fuente)
        {
            return await (from tema in DBLoContext.eva_planeacion_fuentes
                          where tema.IdAsignatura == Fuente.IdAsignatura
                          where tema.IdPlaneacion == Fuente.IdPlaneacion
                          select tema).AsNoTracking().ToListAsync();
        }

        public async Task<string> InsertFuente(eva_planeacion_fuentes Fuente)
        {
            try
            {
                var fuentes = await (from fuente in DBLoContext.eva_planeacion_fuentes
                                      where fuente.IdAsignatura == Fuente.IdAsignatura
                                      where fuente.IdPlaneacion == Fuente.IdPlaneacion
                                      where fuente.IdFuente == Fuente.IdFuente
                                      select fuente).AsNoTracking().ToListAsync();
                if (fuentes.Count() > 0)
                {
                    return "Exists";
                }
                await DBLoContext.AddAsync(Fuente);
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "Ok" : "Error al insertar tema";
                DBLoContext.Entry(Fuente).State = EntityState.Detached;
                return res;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public async Task<string> UpdateFuente(eva_planeacion_fuentes Fuente)
        {
            try
            {
                DBLoContext.Entry(Fuente).State = EntityState.Modified;
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "Error al actualizar tema";
                DBLoContext.Entry(Fuente).State = EntityState.Detached;
                return res;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public async Task<string> DeleteFuente(eva_planeacion_fuentes Fuente)
        {
            DBLoContext.eva_planeacion_fuentes.Remove(Fuente);
            return await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "Error al eliminar tema";
        }

        
    }
}

