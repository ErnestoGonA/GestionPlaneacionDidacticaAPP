using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion_Apoyos;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Services.Planeacion_Apoyos
{
    public class FicSrvPlaneacionApoyos : IFicSrvPlaneacionApoyos
    {
        private readonly DBContext DBLoContext;

        public FicSrvPlaneacionApoyos()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        public async Task<IEnumerable<eva_planeacion_apoyos>> MetGetListPlaneacionAPoyos()
        {
            return await (from papoyos in DBLoContext.eva_planeacion_apoyos select papoyos).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<eva_planeacion_apoyos>> MetGetListApoyosPlaneacion(eva_planeacion Planeacion)
        {
            return await (from papoyos in DBLoContext.eva_planeacion_apoyos
                          where papoyos.IdPlaneacion == Planeacion.IdPlaneacion
                          where papoyos.IdAsignatura == Planeacion.IdAsignatura
                          select papoyos).AsNoTracking().ToListAsync();
        }

        public async Task<string> InsertPlaneacionApoyos(eva_planeacion_apoyos Apoyo)
        {
            try
            {
                await DBLoContext.AddAsync(Apoyo);
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "Ok" : "ERROR AL INSERTAR APOYOPLANEACION";
                DBLoContext.Entry(Apoyo).State = EntityState.Detached;
                return res;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public async Task<IEnumerable<eva_cat_apoyos_didacticos>> GetListApoyosDidacticos()
        {
            return await(from apoyos in DBLoContext.eva_cat_apoyos_didacticos select apoyos).AsNoTracking().ToListAsync();
        }

        public async Task<string> UpdatePlaneacionApoyos(eva_planeacion_apoyos Apoyo)
        {
            try
            {
                DBLoContext.Update(Apoyo);
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL ACTUALIZAR LA PLANEACION_APOYOS";
                DBLoContext.Entry(Apoyo).State = EntityState.Detached;
                return res;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
