using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using GestionPlaneacionDidacticaAPP.Interfaces.SQLite;
using GestionPlaneacionDidacticaAPP.Droid.SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConfigSQLiteDROID))]
namespace GestionPlaneacionDidacticaAPP.Droid.SQLite
{
    class ConfigSQLiteDROID : ConfigSQLite
    {

        public string GetDataBasePath()
        {
            var PathFile = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads);
            var DirectorioDB = PathFile.Path;
            DirectorioDB = DirectorioDB + "/DB/";
            string EGAPathDB = Path.Combine(DirectorioDB, AppSettings.DataBaseName);
            return EGAPathDB;

        }

    }
}
