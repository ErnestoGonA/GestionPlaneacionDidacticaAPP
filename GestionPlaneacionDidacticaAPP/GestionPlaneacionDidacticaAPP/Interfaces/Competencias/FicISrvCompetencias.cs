﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Interfaces.Competencias
{
    public interface FicISrvCompetencias
    {
        Task<IEnumerable<eva_planeacion_temas_competencias>> MetGetListCompetencias();
        //Task<IEnumerable<eva>> MetGetListTemasPlaneacion(int IdPlaneacion);
        Task<string> InsertCompetencia(eva_planeacion_temas_competencias Compe);

        Task<string> UpdateCompetencia(eva_planeacion_temas_competencias Compe);

        Task<string> DeleteCompetencia(eva_planeacion_temas_competencias Compe);
    }
}
