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
    }
}
