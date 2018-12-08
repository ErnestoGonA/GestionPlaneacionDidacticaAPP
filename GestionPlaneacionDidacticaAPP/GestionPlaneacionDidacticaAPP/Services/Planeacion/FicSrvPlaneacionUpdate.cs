using GestionPlaneacionDidacticaAPP.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion;
using GestionPlaneacionDidacticaAPP.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GestionPlaneacionDidacticaAPP.Services.Planeacion
{
    public class FicSrvPlaneacionUpdate : IFicSrvPlaneacionUpdate
    {
        private readonly DBContext DBLoContext;
        public FicSrvPlaneacionUpdate()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        public async Task<IEnumerable<cat_periodos>> GetListPeriodos()
        {
            return await (from periodos in DBLoContext.cat_periodos select periodos).AsNoTracking().ToListAsync();
        }

        public async Task<string> Update_eva_planeacion(eva_planeacion eva_planeacion)
        {
            try
            {
                DBLoContext.Update(eva_planeacion);
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL ACTUALIZAR LA PLAENACION";
                DBLoContext.Entry(eva_planeacion).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                return res;
            }catch(Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
