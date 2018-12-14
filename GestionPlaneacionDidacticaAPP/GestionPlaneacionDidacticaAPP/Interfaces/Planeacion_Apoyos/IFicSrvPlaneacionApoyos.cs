using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Interfaces.Planeacion_Apoyos
{
    public interface IFicSrvPlaneacionApoyos
    {
        Task<IEnumerable<eva_planeacion_apoyos>> MetGetListPlaneacionAPoyos();

        Task<IEnumerable<eva_planeacion_apoyos>> MetGetListApoyosPlaneacion(eva_planeacion Planeacion);

        Task<string> InsertPlaneacionApoyos(eva_planeacion_apoyos Apoyo);

        Task<string> UpdatePlaneacionApoyos(eva_planeacion_apoyos Apoyo);

        Task<string> DeletePlaneacionApoyos(eva_planeacion_apoyos Apoyo);

        Task<IEnumerable<eva_cat_apoyos_didacticos>> GetListApoyosDidacticos();
    }
}
