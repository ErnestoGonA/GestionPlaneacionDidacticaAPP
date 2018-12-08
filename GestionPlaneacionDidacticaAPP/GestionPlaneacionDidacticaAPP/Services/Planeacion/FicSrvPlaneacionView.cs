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
    public class FicSrvPlaneacionView : IFicSrvPlaneacionView
    {
        private readonly DBContext DBLoContext;
        public FicSrvPlaneacionView()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        public async Task<eva_cat_asignaturas> FicMetGetAsignatura(int IdAsignatura)
        {
            List<eva_cat_asignaturas> aux = await (from asignatura in DBLoContext.eva_cat_asignaturas select asignatura).Where((asignatura) => asignatura.IdAsignatura == IdAsignatura).AsNoTracking().ToListAsync();
            eva_cat_asignaturas asignaturaItem = new eva_cat_asignaturas();
            aux.ForEach(item => {
                asignaturaItem = item;
            });
            return asignaturaItem;
        }

        public async Task<cat_periodos> FicMetGetPeriodo(int IdPeriodo)
        {
            List<cat_periodos> aux = await (from periodo in DBLoContext.cat_periodos select periodo).Where((periodo) => periodo.IdPeriodo == IdPeriodo).AsNoTracking().ToListAsync();
            cat_periodos periodoItem=new cat_periodos();
            aux.ForEach(item => {
                periodoItem = item;
            });
            return periodoItem;
        }
    }
}
