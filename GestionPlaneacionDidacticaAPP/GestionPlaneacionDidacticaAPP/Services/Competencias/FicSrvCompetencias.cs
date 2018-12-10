﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Competencias;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Services.Competencias
{
    public class FicSrvCompetencias : IFicSrvCompetencias
    {
        private readonly DBContext DBLoContext;

        public FicSrvCompetencias()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        public Task<string> DeleteCompetencia(eva_planeacion_temas_competencias Compe)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<eva_cat_competencias>> GetListCompetencias()
        {
            return await(from competencias in DBLoContext.eva_cat_competencias select competencias).AsNoTracking().ToListAsync();
        }

        public async Task<string> InsertCompetencia(eva_planeacion_temas_competencias Compe)
        {
            try
            {
                await DBLoContext.AddAsync(Compe);
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "Ok" : "ERROR AL ISNERTA LA COMPETENCIA";
                DBLoContext.Entry(Compe).State = EntityState.Detached;
                return res;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        //Lista todos los apoyos_didacticos
        public async Task<IEnumerable<eva_planeacion_temas_competencias>> MetGetListCompetencias()
        {
            return await (from compe in DBLoContext.eva_planeacion_temas_competencias select compe).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<eva_planeacion_temas_competencias>> MetGetListCompetenciasTemasPlaneacion(int IdTema)
        {
            return await(from tema in DBLoContext.eva_planeacion_temas_competencias
                         where tema.IdTema == IdTema
                         select tema).AsNoTracking().ToListAsync();
        }

        public Task<string> UpdateCompetencia(eva_planeacion_temas_competencias Compe)
        {
            throw new NotImplementedException();
        }
    }
}
