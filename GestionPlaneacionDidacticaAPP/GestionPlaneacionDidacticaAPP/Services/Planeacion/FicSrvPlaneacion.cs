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

        public async Task<IEnumerable<eva_cat_asignaturas>> FicMetGetListAsignatura()
        {
            return await (from asignatura in DBLoContext.eva_cat_asignaturas select asignatura).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<eva_planeacion>> FicMetGetListPlaneacion()
        {
            return await(from planeacion in DBLoContext.eva_planeacion select planeacion).AsNoTracking().ToListAsync();
        }
    }
}
