using GestionPlaneacionDidacticaAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionPlaneacionDidacticaAPP.Interfaces.Planeacion
{
    public interface IFicSrvPlaneacionInsert
    {
        Task<string> Insert_eva_planeacion(eva_planeacion eva_planeacion);
    }
}
