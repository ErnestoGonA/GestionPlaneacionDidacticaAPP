using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Windows.Storage;
using Xamarin.Forms;

using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.UWP.SQLite;

[assembly: Dependency(typeof(ConfigSQliteUWP))]
namespace GestionPlaneacionDidacticaAPP.UWP.SQLite
{
    class ConfigSQliteUWP : ConfigSQLite
    {
        public string GetDataBasePath()
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, AppSettings.DataBaseName);
        }

    }
}
