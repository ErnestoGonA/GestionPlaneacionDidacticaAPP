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
    public class FicSrvPlaneacionGuardarComo : IFicSrvGuardarComo
    {
        private readonly DBContext DBLoContext;
        public FicSrvPlaneacionGuardarComo()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        public async Task<IEnumerable<cat_periodos>> GetListPeriodos()
        {
            return await (from periodos in DBLoContext.cat_periodos select periodos).AsNoTracking().ToListAsync();
        }

        public async Task<string> SaveAs_eva_planeacion(eva_planeacion eva_planeacion)
        {
            try
            {
                await DBLoContext.AddAsync(eva_planeacion);
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL INSERTAR UNA PLANEACION";
                DBLoContext.Entry(eva_planeacion).State = EntityState.Detached;
                return res;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
