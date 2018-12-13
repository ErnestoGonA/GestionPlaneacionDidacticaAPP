using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Aprendizajes;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Services.Aprendizajes
{
    public class FicSrvAprendizajes : IFicSrvAprendizajes
    {

        private readonly DBContext DBLoContext;

        public FicSrvAprendizajes()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }


        public Task<string> DeleteAprendizaje(eva_planeacion_aprendizaje Aprendizaje)
        {
            throw new NotImplementedException();
        }

        public Task<string> InsertAprendizaje(eva_planeacion_aprendizaje Aprendizaje)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<eva_planeacion_aprendizaje>> MetGetListAprendizajes()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<eva_planeacion_aprendizaje>> MetGetListAprendizajes(eva_planeacion_temas_competencias eptc)
        {
            return await (from aprendizaje in DBLoContext.eva_planeacion_aprendizaje
                          where aprendizaje.IdAsignatura == eptc.IdAsignatura
                         where aprendizaje.IdPlaneacion == eptc.IdPlaneacion
                         where aprendizaje.IdTema == eptc.IdTema
                         where aprendizaje.IdCompetencia == eptc.IdCompetencia
                         select aprendizaje).AsNoTracking().ToListAsync();
        }

        public Task<string> UpdateAprendizaje(eva_planeacion_aprendizaje Aprendizaje)
        {
            throw new NotImplementedException();
        }
    }
}
