using GestionPlaneacionDidacticaAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionPlaneacionDidacticaAPP.Interfaces.Planeacion
{
    public interface IFicSrvPlaneacionUpdate
    {
        Task<string> Update_eva_planeacion(eva_planeacion eva_planeacion);
        Task<IEnumerable<cat_periodos>> GetListPeriodos();
    }
}
