using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.ActividadEnseñanza;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Models;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;
using System.Linq;

namespace GestionPlaneacionDidacticaAPP.Services.ActividadEnseñanza
{
    public class FicSrvActividadEnseñanza : IFicSrvActividadEnseñanza
    {
        private readonly DBContext DBLoContext;
        public FicSrvActividadEnseñanza()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }
        public async Task<string> FicMetAddActividadEnseñanza(eva_cat_actividades_enseñanza eva_cat_actividades_enseñanza)
        {
            try
            {
                var actividad = await (from pla in DBLoContext.eva_cat_actividades_enseñanza select pla).ToListAsync();

                int maxId = 0;
                if (actividad.Count() > 0)
                {
                    maxId = (from pla in DBLoContext.eva_cat_actividades_enseñanza select pla.IdActividadEnseñanza).Max();
                }

                eva_cat_actividades_enseñanza.IdActividadEnseñanza = ++maxId;


                await DBLoContext.AddAsync(eva_cat_actividades_enseñanza);
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL INSERTAR UNA PLANEACION";
                DBLoContext.Entry(eva_cat_actividades_enseñanza).State = EntityState.Detached;
                return res;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public async Task<eva_cat_actividades_enseñanza> FicMetGetActividadEnseñanza(int id)
        {
            var aux = await(from actividad in DBLoContext.eva_cat_actividades_enseñanza select actividad).Where(item => item.IdActividadEnseñanza == id).AsNoTracking().ToListAsync();
            eva_cat_actividades_enseñanza asignaturaItem = new eva_cat_actividades_enseñanza();
            aux.ForEach(item =>
            {
                asignaturaItem = item;
            });
            return asignaturaItem;
        }

        public async Task<IEnumerable<eva_cat_actividades_enseñanza>> FicMetGetListActividadEnseñanza()
        {
            return await (from enseñanza in DBLoContext.eva_cat_actividades_enseñanza select enseñanza).AsNoTracking().ToListAsync();
        }

        public async Task<string> FicMetRemoveEnseñanza(eva_cat_actividades_enseñanza eva_cat_actividades_enseñanza)
        {
            DBLoContext.Remove(eva_cat_actividades_enseñanza);
            return await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL ELIMINAR";
        }

        public async Task<string> FicMetUpdateEnseñanza(eva_cat_actividades_enseñanza eva_cat_actividades_enseñanza)
        {
            try
            {
                DBLoContext.Update(eva_cat_actividades_enseñanza);
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL ACTUALIZAR LA PLAENACION";
                DBLoContext.Entry(eva_cat_actividades_enseñanza).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                return res;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
