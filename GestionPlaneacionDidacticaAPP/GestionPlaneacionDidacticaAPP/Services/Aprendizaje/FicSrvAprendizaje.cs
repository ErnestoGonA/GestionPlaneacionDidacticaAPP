using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;
using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Apredizaje;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Services.Aprendizaje
{
    public class FicSrvAprendizaje : IFicSrvAprendizaje
    {
        private readonly DBContext DBLoContext;

        public FicSrvAprendizaje()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        public async Task<IEnumerable<eva_planeacion_aprendizaje>> MetGetListAprendizaje()
        {
            return await (from aprendizaje in DBLoContext.eva_planeacion_aprendizaje select aprendizaje).AsNoTracking().ToListAsync();
        }
        
        public async Task<string> InsertAprendizaje(eva_planeacion_aprendizaje aprendizaje)
        {
            try
            {
                await DBLoContext.AddAsync(aprendizaje);
                return await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "Error al insertar";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }            
        }               

        public async Task<string> UpdateAprendizaje(eva_planeacion_aprendizaje aprendizaje)
        {
            try
            {
                DBLoContext.Update(aprendizaje);
                return await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "Error al actualizar";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }            
        }

        public async Task<string> RemoveAprendizaje(eva_planeacion_aprendizaje aprendizaje)
        {
            DBLoContext.Remove(aprendizaje);
            return await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "Error al eliminnar";            
        }
        
    }
}
