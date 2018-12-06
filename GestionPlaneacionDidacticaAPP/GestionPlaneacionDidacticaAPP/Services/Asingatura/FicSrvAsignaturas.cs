using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Asignatura;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Services.Asingatura
{
    public class FicSrvAsignaturas : IFicSrvAsignatura
    {

        private readonly DBContext DBLoContext;

        public FicSrvAsignaturas()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        public async Task<eva_cat_asignaturas> GetAsignatura(short IdAsingatura)
        {
            return await (from asignatura in DBLoContext.eva_cat_asignaturas where asignatura.IdAsignatura==IdAsingatura select asignatura).AsNoTracking().FirstAsync();
        }

        public Task<IEnumerable<eva_cat_asignaturas>> GetListAsingaturas()
        {
            throw new NotImplementedException();
        }
    }
}
