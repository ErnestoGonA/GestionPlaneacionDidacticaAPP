using System;
using System.Collections.Generic;
using System.Text;

namespace GestionPlaneacionDidacticaAPP.Interfaces.SQLite
{
    public interface ConfigSQLite
    {
        /*A TRAVES DE ESTE METODO LOGRAREMOS SOBRE CARGAR EN TODAS
         * LAS PLATAFORMAS LA RUTA DONDE SE CREA LA BASE DE DATOS
         * Y GRACIAS A ESO PODREMOS USARLA EN LA APP PARA LOS SERVICIOS*/
        string GetDataBasePath();
    }
}
