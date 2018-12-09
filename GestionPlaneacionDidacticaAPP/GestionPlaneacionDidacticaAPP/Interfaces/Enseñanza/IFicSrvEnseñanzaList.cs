using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Interfaces.Enseñanza
{
    public interface IFicSrvEnseñanzaList
    {
        Task<IEnumerable<eva_planeacion_enseñanza>> FicMetGetListEnseñanza();
        Task<string> FicMetRemoveEnseñanza();
    }
}
