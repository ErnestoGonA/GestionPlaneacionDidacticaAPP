using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Interfaces.Subtemas;
using GestionPlaneacionDidacticaAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GestionPlaneacionDidacticaAPP.Services.Subtemas
{
    public class FicSrvSubtemas : IFicSrvSubtemas
    {
        private readonly DBContext DBLoContext;
        public FicSrvSubtemas()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        public async Task<IEnumerable<eva_planeacion_subtemas>> FicMetGetListSubtemas()
        {
            return await(from subtema in DBLoContext.eva_planeacion_subtemas select subtema).AsNoTracking().ToListAsync();
        }


    }
}
