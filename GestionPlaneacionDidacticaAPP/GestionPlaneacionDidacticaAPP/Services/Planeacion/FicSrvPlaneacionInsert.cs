using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion;
using System;
using System.Collections.Generic;
using System.Text;
using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using Xamarin.Forms;
using GestionPlaneacionDidacticaAPP.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GestionPlaneacionDidacticaAPP.Services.Planeacion
{
    public class FicSrvPlaneacionInsert : IFicSrvPlaneacionInsert
    {
        private readonly DBContext dBContext;

        public FicSrvPlaneacionInsert()
        {
            dBContext = new DBContext(DependencyService.Get<ConfigSQLite>().GetDataBasePath());
        }

        public async Task<string> Insert_eva_planeacion(eva_planeacion eva_planeacion)
        {
            try
            {
                var planeacion = await (from pla in dBContext.eva_planeacion
                                   where pla.IdAsignatura == eva_planeacion.IdAsignatura
                                   where pla.IdPlaneacion == eva_planeacion.IdPlaneacion
                                   select pla).ToListAsync();

                int maxId = 0;
                if (planeacion.Count() > 0)
                {
                    maxId = (from pla in dBContext.eva_planeacion
                             where pla.IdAsignatura == eva_planeacion.IdAsignatura
                             where pla.IdPlaneacion == eva_planeacion.IdPlaneacion
                             select pla.IdPlaneacion).Max();
                }

                eva_planeacion.IdPlaneacion = ++maxId;
                await dBContext.AddAsync(eva_planeacion);
                var res = await dBContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL INSERTAR UNA PLANEACION";
                dBContext.Entry(eva_planeacion).State = EntityState.Detached;
                return res;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
