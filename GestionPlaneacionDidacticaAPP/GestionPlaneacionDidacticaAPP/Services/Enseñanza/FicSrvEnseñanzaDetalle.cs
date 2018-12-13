using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GestionPlaneacionDidacticaAPP.Interfaces.Enseñanza;
using GestionPlaneacionDidacticaAPP.Data;
using Xamarin.Forms;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GestionPlaneacionDidacticaAPP.Services.Enseñanza
{
    public class FicSrvEnseñanzaDetalle : IFicSrvEnseñanzaDetalle
    {
        private readonly DBContext DBLoContext;
        public FicSrvEnseñanzaDetalle()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        public async Task<eva_cat_asignaturas> FicMetGetAsignatura(int id)
        {
            var aux = await(from asignatura in DBLoContext.eva_cat_asignaturas select asignatura).Where(item => item.IdAsignatura == id).AsNoTracking().ToListAsync();
            eva_cat_asignaturas asignaturaItem = new eva_cat_asignaturas();
            aux.ForEach(item =>
            {
                asignaturaItem = item;
            });
            return asignaturaItem;
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

        public async Task<eva_cat_competencias> FicMetGetCompetencia(int id)
        {
            var aux = await(from competencia in DBLoContext.eva_cat_competencias select competencia).Where(item => item.IdCompetencia == id).AsNoTracking().ToListAsync();
            eva_cat_competencias competenciaItem = new eva_cat_competencias();
            aux.ForEach(item =>
            {
                competenciaItem = item;
            });
            return competenciaItem;
        }

        public async Task<eva_planeacion_enseñanza> FicMetGetEnseñanza(int id)
        {
            var aux = await (from enseñanza in DBLoContext.eva_planeacion_enseñanza select enseñanza).Where(item => item.IdActividadEnseñanza == id).AsNoTracking().ToListAsync();
            eva_planeacion_enseñanza enseñanzaItem = new eva_planeacion_enseñanza();
            aux.ForEach(item =>
            {
                enseñanzaItem = item;
            });
            return enseñanzaItem;
        }

        public async Task<eva_planeacion> FicMetGetPlaneacion(int id)
        {
            var aux = await(from planeacion in DBLoContext.eva_planeacion select planeacion).Where(item => item.IdPlaneacion == id).AsNoTracking().ToListAsync();
            eva_planeacion planeacionItem = new eva_planeacion();
            aux.ForEach(item =>
            {
                planeacionItem = item;
            });
            return planeacionItem;
        }

        public async Task<eva_planeacion_temas> FicMetGetTema(int id)
        {
            var aux = await(from tema in DBLoContext.eva_planeacion_temas select tema).Where(item => item.IdTema == id).AsNoTracking().ToListAsync();
            eva_planeacion_temas temaItem = new eva_planeacion_temas();
            aux.ForEach(item =>
            {
                temaItem = item;
            });
            return temaItem;
        }
    }
}
