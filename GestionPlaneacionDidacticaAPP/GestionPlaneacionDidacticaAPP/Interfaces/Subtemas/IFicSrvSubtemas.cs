using GestionPlaneacionDidacticaAPP.Models;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionPlaneacionDidacticaAPP.Interfaces.Subtemas
{
    public interface IFicSrvSubtemas
    {
        Task<IEnumerable<eva_planeacion_subtemas>> FicMetGetListSubtemas();
        Task<IEnumerable<eva_planeacion_subtemas>> MetGetListSubtemasTema(int IdTema);
        Task<string> InsertSubtema(eva_planeacion_subtemas Subtema);
        Task<string> UpdateSubtema(eva_planeacion_subtemas Subtema);
        Task<string> DeleteSubtema(eva_planeacion_subtemas Subtema);
    }
}
