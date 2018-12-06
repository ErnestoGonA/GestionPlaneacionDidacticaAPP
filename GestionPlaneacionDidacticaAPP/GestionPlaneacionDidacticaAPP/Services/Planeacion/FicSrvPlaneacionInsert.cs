using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion;
using System;
using System.Collections.Generic;
using System.Text;
using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using Xamarin.Forms;
using GestionPlaneacionDidacticaAPP.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GestionPlaneacionDidacticaAPP.Services.Planeacion
{
    public class FicSrvPlaneacionInsert : IFicSrvPlaneacionInsert
    {
        private readonly DBContext dBContext;

        public FicSrvPlaneacionInsert()
        {
            dBContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        public async Task<IEnumerable<cat_periodos>> GetListPeriodos()
        {
            return await (from periodos in dBContext.cat_periodos select periodos).AsNoTracking().ToListAsync();
        }

        public async Task<string> Insert_eva_planeacion(eva_planeacion eva_planeacion)
        {
            try
            {
                await dBContext.AddAsync(eva_planeacion);
                var res = await dBContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL INSERTAR UNA PLANEACION";
                dBContext.Entry(eva_planeacion).State = EntityState.Detached;
                return res;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
