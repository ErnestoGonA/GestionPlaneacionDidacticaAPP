using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion;
using GestionPlaneacionDidacticaAPP.Data;
using Xamarin.Forms;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GestionPlaneacionDidacticaAPP.Services.Planeacion
{
    public class FicSrvPlaneacion: FicISrvPlaneacion
    {
        private readonly DBContext DBLoContext;
        public FicSrvPlaneacion()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        public async Task<IEnumerable<cat_periodos>> GetListPeriodos()
        {
            return await (from periodos in DBLoContext.cat_periodos select periodos).AsNoTracking().ToListAsync();
        }

        public async Task<cat_periodos> GetListPeriodos(short IdPeriodo)
        {
            return await DBLoContext.cat_periodos.FindAsync(IdPeriodo);
        }

        public async Task<IEnumerable<eva_cat_asignaturas>> FicMetGetListAsignatura()
        {
            return await (from asignatura in DBLoContext.eva_cat_asignaturas select asignatura).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<eva_planeacion>> FicMetGetListPlaneacion()
        {
            return await(from planeacion in DBLoContext.eva_planeacion select planeacion).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<eva_planeacion>> FicMetGetListPlaneacionPlantilla(int IdAsignatura, bool PlantillaOriginal,Int16 IdPeriodo)
        {
            string PlantillaOriginalString = PlantillaOriginal ? "S" : "N";
            return await(from planeacion in DBLoContext.eva_planeacion select planeacion).Where(Planeacion =>
                Planeacion.IdAsignatura == IdAsignatura && Planeacion.PlantillaOriginal.Equals(PlantillaOriginalString) && Planeacion.IdPeriodo == IdPeriodo
            ).AsNoTracking().ToListAsync();
        }

        public async Task<string> FicMetRemovePlaneacion(eva_planeacion eva_planeacion)
        {
            int id = eva_planeacion.IdPlaneacion;
            List<eva_planeacion_mejora_desempeño> mejoras = await (from mejora in DBLoContext.eva_planeacion_mejor_desempeño select mejora).Where(item => item.IdPlaneacion == id).AsNoTracking().ToListAsync();
            mejoras.ForEach(item =>
            {
                DBLoContext.Remove(item);
            });
            List<eva_planeacion_criterios_evalua> criterios = await (from criterio in DBLoContext.eva_planeacion_criterios_evalua select criterio).Where(item => item.IdPlaneacion == id).AsNoTracking().ToListAsync();
            criterios.ForEach(item =>
            {
                DBLoContext.Remove(item);
            });
            List<eva_planeacion_enseñanza> enseñanzas = await (from enseñanza in DBLoContext.eva_planeacion_enseñanza select enseñanza).Where(item => item.IdPlaneacion == id).AsNoTracking().ToListAsync();
            enseñanzas.ForEach(item =>
            {
                DBLoContext.Remove(item);
            });
            List<eva_planeacion_aprendizaje> aprendizajes = await (from aprendizaje in DBLoContext.eva_planeacion_aprendizaje select aprendizaje).Where(item => item.IdPlaneacion == id).AsNoTracking().ToListAsync();
            aprendizajes.ForEach(item =>
            {
                DBLoContext.Remove(item);
            });
            List<eva_planeacion_temas_competencias> temas_competencias = await (from temaC in DBLoContext.eva_planeacion_temas_competencias select temaC).Where(item => item.IdPlaneacion == id).AsNoTracking().ToListAsync();
            temas_competencias.ForEach(item =>
            {
                DBLoContext.Remove(item);
            });
            List<eva_planeacion_apoyos> apoyos = await (from apoyo in DBLoContext.eva_planeacion_apoyos select apoyo).Where(item => item.IdPlaneacion == id).AsNoTracking().ToListAsync();
            apoyos.ForEach(item =>
            {
                DBLoContext.Remove(item);
            });
            List<eva_planeacion_fuentes> fuentes = await (from fuente in DBLoContext.eva_planeacion_fuentes select fuente).Where(item => item.IdPlaneacion == id).AsNoTracking().ToListAsync();
            fuentes.ForEach(item =>
            {
                DBLoContext.Remove(item);
            });
            List<eva_planeacion_subtemas> subtemas = await (from subtema in DBLoContext.eva_planeacion_subtemas select subtema).Where(item => item.IdPlaneacion == id).AsNoTracking().ToListAsync();
            subtemas.ForEach(item => 
            {
                DBLoContext.Remove(item);
            });
            List<eva_planeacion_temas> temas = await (from tema in DBLoContext.eva_planeacion_temas select tema).Where(item => item.IdPlaneacion == id).AsNoTracking().ToListAsync();
            temas.ForEach(item => 
            {
                DBLoContext.Remove(item);
            });
            DBLoContext.Remove(eva_planeacion);
            return await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL ELIMINAR";
        }
    }
}
