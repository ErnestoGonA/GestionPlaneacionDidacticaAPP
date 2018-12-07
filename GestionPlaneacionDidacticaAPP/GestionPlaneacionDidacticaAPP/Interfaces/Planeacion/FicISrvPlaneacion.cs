﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Interfaces.Planeacion
{
    public interface FicISrvPlaneacion
    {
        Task<IEnumerable<eva_planeacion>> FicMetGetListPlaneacion();
        Task<IEnumerable<eva_cat_asignaturas>> FicMetGetListAsignatura();
    }
}
