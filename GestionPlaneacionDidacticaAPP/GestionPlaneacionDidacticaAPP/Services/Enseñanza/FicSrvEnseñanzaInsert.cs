using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GestionPlaneacionDidacticaAPP.Data;
using Xamarin.Forms;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestionPlaneacionDidacticaAPP.Interfaces.Enseñanza;

namespace GestionPlaneacionDidacticaAPP.Services.Enseñanza
{
    public class FicSrvEnseñanzaInsert : IFicSrvEnseñanzaInsert
    {
        public readonly DBContext DBLoContext;
        public FicSrvEnseñanzaInsert()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        public async Task<string> FicMetAddEnseñanza(eva_planeacion_enseñanza eva_planeacion_enseñanza)
        {
            try
            {
                await DBLoContext.AddAsync(eva_planeacion_enseñanza);
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL INSERTAR UNA PLANEACION";
                DBLoContext.Entry(eva_planeacion_enseñanza).State = EntityState.Detached;
                return res;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public async Task<IEnumerable<eva_cat_actividades_enseñanza>> FicMetGetActividades()
        {
            return await (from actividad in DBLoContext.eva_cat_actividades_enseñanza select actividad).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<eva_cat_asignaturas>> FicMetGetAsignatura()
        {
            return await(from asignatura in DBLoContext.eva_cat_asignaturas select asignatura).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<eva_cat_competencias>> FicMetGetCompetencia()
        {
            return await (from competencia in DBLoContext.eva_cat_competencias select competencia).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<eva_planeacion>> FicMetGetPlaneacion()
        {
            return await (from planeacion in DBLoContext.eva_planeacion select planeacion).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<eva_planeacion_temas>> FicMetGetTema()
        {
            return await (from tema in DBLoContext.eva_planeacion_temas select tema).AsNoTracking().ToListAsync();
        }
    }
}
