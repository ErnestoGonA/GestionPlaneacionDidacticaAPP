using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Interfaces.Apoyos_Didacticos
{
    public interface ISrvApoyosDidacticos
    {
        Task<IEnumerable<eva_cat_apoyos_didacticos>> MetGetListApoyosDidacticos();
        //Task<IEnumerable<eva>> MetGetListTemasPlaneacion(int IdPlaneacion);
        Task<string> InsertApoyoDidactico(eva_cat_apoyos_didacticos ApoDid);

        Task<string> UpdateApoyoDidactico(eva_cat_apoyos_didacticos ApoDid);

        Task<string> DeleteApoyoDidactico(eva_cat_apoyos_didacticos ApoDid);
    }
}
