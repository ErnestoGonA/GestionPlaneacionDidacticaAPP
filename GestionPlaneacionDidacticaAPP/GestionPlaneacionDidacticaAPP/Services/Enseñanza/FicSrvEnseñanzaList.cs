using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GestionPlaneacionDidacticaAPP.Data;
using Xamarin.Forms;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestionPlaneacionDidacticaAPP.Interfaces.Enseñanza;

namespace GestionPlaneacionDidacticaAPP.Services.Enseñanza
{
    public class FicSrvEnseñanzaList : IFicSrvEnseñanzaList
    {
        private readonly DBContext DBLoContext;
        public FicSrvEnseñanzaList()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        public async Task<IEnumerable<eva_planeacion_enseñanza>> FicMetGetListEnseñanza()
        {
            return await (from enseñanza in DBLoContext.eva_planeacion_enseñanza select enseñanza).AsNoTracking().ToListAsync();
        }

        public Task<string> FicMetRemoveEnseñanza()
        {
            throw new NotImplementedException();
        }
    }
}
