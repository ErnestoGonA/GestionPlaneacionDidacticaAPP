using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Interfaces.Planeacion
{
    public interface IFicSrvPlaneacionView
    {
        Task<eva_cat_asignaturas> FicMetGetAsignatura(int IdAsignatura);
        Task<cat_periodos> FicMetGetPeriodo(int IdPeriodo);
    }
}
