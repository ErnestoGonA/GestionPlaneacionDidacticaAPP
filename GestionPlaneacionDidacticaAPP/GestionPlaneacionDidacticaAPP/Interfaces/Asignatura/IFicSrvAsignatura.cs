using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Interfaces.Asignatura
{
    public interface IFicSrvAsignatura
    {
        Task<IEnumerable<eva_cat_asignaturas>> GetListAsingaturas();
        Task<eva_cat_asignaturas> GetAsignatura(short IdAsingatura);
    }
}
