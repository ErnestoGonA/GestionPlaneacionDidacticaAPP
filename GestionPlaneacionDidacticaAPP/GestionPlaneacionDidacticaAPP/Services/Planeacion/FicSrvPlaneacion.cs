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

        public async Task<IEnumerable<eva_cat_asignaturas>> FicMetGetListAsignatura()
        {
            return await (from asignatura in DBLoContext.eva_cat_asignaturas select asignatura).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<eva_planeacion>> FicMetGetListPlaneacion()
        {
            return await(from planeacion in DBLoContext.eva_planeacion select planeacion).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<eva_planeacion>> FicMetGetListPlaneacionPlantilla(int IdAsignatura, bool PlantillaOriginal)
        {
            string PlantillaOriginalString = PlantillaOriginal ? "1" : "0";
            return await(from planeacion in DBLoContext.eva_planeacion select planeacion).Where(Planeacion =>
                Planeacion.IdAsignatura == IdAsignatura && Planeacion.PlantillaOriginal.Equals(PlantillaOriginalString)
            ).AsNoTracking().ToListAsync();
        }

        public async Task<string> FicMetRemovePlaneacion(eva_planeacion eva_planeacion)
        {
            DBLoContext.Remove(eva_planeacion);
            return await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL ELIMINAR";
        }
    }
}
