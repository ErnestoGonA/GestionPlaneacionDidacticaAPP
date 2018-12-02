using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Temas;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Services.Temas
{
    public class SrvTemas : ISrvTemas
    {

        private readonly DBContext DBLoContext;

        public SrvTemas()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        //List all temas
        public async Task<IEnumerable<eva_planeacion_temas>> MetGetListTemas()
        {
            return await (from tema in DBLoContext.eva_planeacion_temas select tema).AsNoTracking().ToListAsync();  
        }

        //List temas of a planeacion
        public async Task<IEnumerable<eva_planeacion_temas>> MetGetListTemas(int IdPlaneacion)
        {
            return await(from tema in DBLoContext.eva_planeacion_temas
                         where tema.IdPlaneacion== IdPlaneacion select tema).AsNoTracking().ToListAsync();
        }

        public async Task<string> InsertTema(eva_planeacion_temas Tema)
        {
            try
            {
                await DBLoContext.AddAsync(Tema);
                return await DBLoContext.SaveChangesAsync() > 0 ? "Ok" : "Error al insertar tema";
            }
            catch(Exception e)
            {
                return e.Message.ToString();
            }
        }

        public async Task<string> UpdateTema(eva_planeacion_temas Tema)
        {
            try
            {
                DBLoContext.Update(Tema);
                return await DBLoContext.SaveChangesAsync() > 0 ? "Ok" : "Error al actualizar tema";
            }
            catch(Exception e)
            {
                return e.Message.ToString();
            }
        }

        public async Task<string> DeleteTema(eva_planeacion_temas Tema)
        {
            DBLoContext.Remove(Tema);
            return await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "Error al eliminar tema";
        }
        
    }
}
