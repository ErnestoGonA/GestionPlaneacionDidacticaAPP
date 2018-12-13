using GestionPlaneacionDidacticaAPP.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Interfaces.Enseñanza;
using GestionPlaneacionDidacticaAPP.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GestionPlaneacionDidacticaAPP.Services.Enseñanza
{
    class FicSrvEnseñanzaUpdate : IFicSrvEnseñanzaUpdate
    {
        private readonly DBContext DBLoContext;
        public FicSrvEnseñanzaUpdate()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        public async Task<eva_cat_actividades_enseñanza> FicMetGetActividad(int id)
        {
            var aux = await (from asignatura in DBLoContext.eva_cat_actividades_enseñanza select asignatura).Where(asignatura => asignatura.IdActividadEnseñanza == id).AsNoTracking().ToListAsync();
            eva_cat_actividades_enseñanza asign = new eva_cat_actividades_enseñanza();
            aux.ForEach(asignatura => {
                asign = asignatura;
            });
            return asign;
        }

        public async Task<IEnumerable<eva_cat_actividades_enseñanza>> FicMetGetActividades()
        {
            return await (from actividad in DBLoContext.eva_cat_actividades_enseñanza select actividad).AsNoTracking().ToListAsync();
        }

        public async Task<string> FicMetUpdateEnseñanza(eva_planeacion_enseñanza eva_planeacion_enseñanza)
        {
            try
            {
                DBLoContext.Update(eva_planeacion_enseñanza);
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL ACTUALIZAR LA PLAENACION";
                DBLoContext.Entry(eva_planeacion_enseñanza).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                return res;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
