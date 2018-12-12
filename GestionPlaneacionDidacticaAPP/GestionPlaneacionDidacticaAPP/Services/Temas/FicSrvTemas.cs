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
    public class FicSrvTemas : IFicSrvTemas
    {

        private readonly DBContext DBLoContext;

        public FicSrvTemas()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        //List all temas
        public async Task<IEnumerable<eva_planeacion_temas>> MetGetListTemas()
        {
            return await (from tema in DBLoContext.eva_planeacion_temas select tema).AsNoTracking().ToListAsync();  
        }

        //List temas of a planeacion
        public async Task<IEnumerable<eva_planeacion_temas>> MetGetListTemasPlaneacion(eva_planeacion Planeacion)
        {
            return await(from tema in DBLoContext.eva_planeacion_temas
                         where tema.IdAsignatura == Planeacion.IdAsignatura
                         where tema.IdPlaneacion== Planeacion.IdPlaneacion
                         select tema).AsNoTracking().ToListAsync();
        }

        public async Task<string> InsertTema(eva_planeacion_temas Tema)
        {
            try
            {

                var temas =await  (from tema in DBLoContext.eva_planeacion_temas
                                   where tema.IdAsignatura==Tema.IdAsignatura
                                   where tema.IdPlaneacion == Tema.IdPlaneacion
                                   select tema).ToListAsync();

                short maxId = 0;
                if (temas.Count()>0)
                {
                    maxId = (from tema in DBLoContext.eva_planeacion_temas
                             where tema.IdAsignatura == Tema.IdAsignatura
                             where tema.IdPlaneacion == Tema.IdPlaneacion
                             select tema.IdTema).Max();
                }

                Tema.IdTema = ++maxId;

                await DBLoContext.AddAsync(Tema);
                var res =  await DBLoContext.SaveChangesAsync() > 0 ? "Ok" : "Error al insertar tema";
                DBLoContext.Entry(Tema).State = EntityState.Detached;
                return res;
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
                DBLoContext.Entry(Tema).State = EntityState.Modified;
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "Error al actualizar tema";
                DBLoContext.Entry(Tema).State = EntityState.Detached;
                return res;
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
