using GestionPlaneacionDidacticaAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionPlaneacionDidacticaAPP.Interfaces.Importar
{
    public interface IFicImportar
    {
        Task<string> FicMetExportar();
        Task<ImportarExportar> FicMetImportar();
    }
}
