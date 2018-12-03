using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Interfaces.Temas
{
    public interface ISrvTemas
    {
        Task<IEnumerable<eva_planeacion_temas>> MetGetListTemas();
        Task<IEnumerable<eva_planeacion_temas>> MetGetListTemasPlaneacion(int IdPlaneacion);
        Task<string> InsertTema(eva_planeacion_temas Tema);
        Task<string> UpdateTema(eva_planeacion_temas Tema);
        Task<string> DeleteTema(eva_planeacion_temas Tema);
    }
}
