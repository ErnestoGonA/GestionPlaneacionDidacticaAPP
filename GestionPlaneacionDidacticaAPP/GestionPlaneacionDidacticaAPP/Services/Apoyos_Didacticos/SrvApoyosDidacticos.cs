using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Apoyos_Didacticos;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Services.Apoyos_Didacticos
{
    public class SrvApoyosDidacticos : ISrvApoyosDidacticos
    {
        private readonly DBContext DBLoContext;

        public SrvApoyosDidacticos()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        //Lista todos los apoyos_didacticos
        public async Task<IEnumerable<eva_cat_apoyos_didacticos>> MetGetListApoyosDidacticos()
        {
            return await (from apodid in DBLoContext.eva_cat_apoyos_didacticos select apodid).AsNoTracking().ToListAsync();
        }

        public async Task<string> InsertApoyoDidactico(eva_cat_apoyos_didacticos ApoDid)
        {
            try
            {
                await DBLoContext.AddAsync(ApoDid);
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "Ok" : "ERROR AL INSERTAR EL APOYO DIDACTICO";
                DBLoContext.Entry(ApoDid).State = EntityState.Detached;
                return res;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public async Task<string> UpdateApoyoDidactico(eva_cat_apoyos_didacticos ApoDid)
        {
            try
            {
                DBLoContext.Update(ApoDid);
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL ACTUALIZAR EL APOYO DIDACTICO";
                DBLoContext.Entry(ApoDid).State = EntityState.Detached;
                return res;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public async Task<string> DeleteApoyoDidactico(eva_cat_apoyos_didacticos ApoDid)
        {
            DBLoContext.Remove(ApoDid);
            return await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL ELIMINAR EL APOYO DIDACTICO";
        }

    }
}
