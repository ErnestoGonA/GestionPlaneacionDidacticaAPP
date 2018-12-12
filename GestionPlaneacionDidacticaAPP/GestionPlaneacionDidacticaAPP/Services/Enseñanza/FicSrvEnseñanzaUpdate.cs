using GestionPlaneacionDidacticaAPP.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Interfaces.Enseñanza;
using GestionPlaneacionDidacticaAPP.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GestionPlaneacionDidacticaAPP.Services.Enseñanza
{
    class FicSrvEnseñanzaUpdate : IFicSrvEnseñanzaUpdate
    {
        private readonly DBContext DBLoContext;
        public FicSrvEnseñanzaUpdate()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        public async Task<string> FicMetUpdateEnseñanza(eva_planeacion_enseñanza eva_planeacion_enseñanza)
        {
            try
            {
                DBLoContext.Update(eva_planeacion_enseñanza);
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL ACTUALIZAR LA PLAENACION";
                DBLoContext.Entry(eva_planeacion_enseñanza).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                return res;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
